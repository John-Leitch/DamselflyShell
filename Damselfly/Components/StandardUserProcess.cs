using Components.PInvoke;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using static Components.PInvoke.TokenAccess;
using static Components.PInvoke.Win32;

namespace Damselfly.Components
{
    public static class StandardUserProcess
    {
        private static readonly Lazy<IntPtr> _duplicatedToken = new Lazy<IntPtr>(DuplicateToken);

        public static NativeProcess Start(string filename, string arguments)
        {
            var si = new STARTUPINFO { cb = Marshal.SizeOf<STARTUPINFO>() };
            var pi = new PROCESS_INFORMATION();
            var sa = new SECURITY_ATTRIBUTES();
            sa.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>();

            ThrowLastErrorIf(
                !AdvApi32.CreateProcessWithTokenW(
                    _duplicatedToken.Value,
                    LogonFlags.WithProfile,
                    filename,
                    arguments,
                    ProcessCreationFlags.None,
                    IntPtr.Zero,
                    null,
                    si,
                    pi));

            return new NativeProcess(pi);
        }

        private static IntPtr DuplicateToken()
        {
            IntPtr procHandle;

            using (var proc = Process.GetProcessesByName("explorer").First())
            {
                ThrowLastErrorIf(
                    (procHandle = Kernel32.OpenProcess(
                        ProcessAccessFlags.QueryInformation,
                        false,
                        proc.Id)) == INVALID_HANDLE_VALUE);
            }

            ThrowLastErrorIf(
                !AdvApi32.OpenProcessToken(
                    procHandle,
                    TOKEN_QUERY | TOKEN_DUPLICATE,
                    out var procTokenHandle));

            ThrowLastErrorIf(
                !AdvApi32.DuplicateTokenEx(
                    procTokenHandle,
                    TOKEN_ASSIGN_PRIMARY |
                        TOKEN_DUPLICATE |
                        TOKEN_QUERY |
                        TOKEN_ADJUST_DEFAULT |
                        TOKEN_ADJUST_SESSIONID,
                    IntPtr.Zero,
                    SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                    TOKEN_TYPE.TokenPrimary,
                    out var duplicateTokenHandle));

            Kernel32.CloseHandle(procTokenHandle);
            Kernel32.CloseHandle(procHandle);

            return duplicateTokenHandle;
        }
    }
}
