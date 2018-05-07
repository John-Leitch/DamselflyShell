using Components.PInvoke;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Damselfly.Components
{
    public static class StandardUserProcess
    {
        public static NativeProcess Start(string filename, string arguments)
        {
            var proc = Process.GetProcessesByName("explorer").Single();

            IntPtr procHandle;

            if ((procHandle = Kernel32.OpenProcess(
                    ProcessAccessFlags.QueryInformation,
                    false,
                    proc.Id)) == Win32.INVALID_HANDLE_VALUE)
            {
                Win32.ThrowWin32Exception();
            }

            IntPtr procTokenHandle;

            if (!AdvApi32.OpenProcessToken(
                procHandle,
                TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE,
                out procTokenHandle))
            {
                Win32.ThrowWin32Exception();
            }

            IntPtr duplicateTokenHandle;

            if (!AdvApi32.DuplicateTokenEx(
                procTokenHandle,
                TokenAccess.TOKEN_ASSIGN_PRIMARY |
                    TokenAccess.TOKEN_DUPLICATE |
                    TokenAccess.TOKEN_QUERY |
                    TokenAccess.TOKEN_ADJUST_DEFAULT |
                    TokenAccess.TOKEN_ADJUST_SESSIONID,
                IntPtr.Zero,
                SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                TOKEN_TYPE.TokenPrimary,
                out duplicateTokenHandle))
            {
                Win32.ThrowWin32Exception();
            }

            var si = new STARTUPINFO { cb = Marshal.SizeOf<STARTUPINFO>() };
            var pi = new PROCESS_INFORMATION();
            var sa = new SECURITY_ATTRIBUTES();
            sa.nLength = Marshal.SizeOf<SECURITY_ATTRIBUTES>();

            if (!AdvApi32.CreateProcessWithTokenW(
                duplicateTokenHandle,
                LogonFlags.WithProfile,
                filename,
                arguments,
                ProcessCreationFlags.None,
                IntPtr.Zero,
                null,
                si,
                pi))
            {
                Win32.ThrowWin32Exception();
            }

            foreach (var h in new[]
            {
                duplicateTokenHandle,
                procTokenHandle,
                procHandle,
                //pi.hProcess,
                //pi.hThread,
            })
            {
                Kernel32.CloseHandle(h);
            }

            return new NativeProcess(pi);
        }
    }
}
