using Components.PInvoke;
using System;

namespace Damselfly.Components
{
    public sealed class NativeProcess : IDisposable
    {
        private PROCESS_INFORMATION _processInfo;
        public IntPtr ProcessHandle => _processInfo.hProcess;
        public IntPtr ThreadHandle => _processInfo.hThread;
        public uint ProcessId => _processInfo.dwProcessId;
        public uint ThreadId => _processInfo.dwThreadId;

        public NativeProcess(PROCESS_INFORMATION processInfo) => _processInfo = processInfo;

        public bool WaitForExit() => WaitForExit(0);

        public bool WaitForExit(int milliseconds)
        {
            if (!Win32.IsHandleValid(ProcessHandle))
            {
                throw new InvalidOperationException(
                    "Invalid handle, could not wait for process to exit.");
            }

            foreach (var h in new[] { ThreadHandle, ProcessHandle })
            {
                if (Kernel32.WaitForSingleObject(ProcessHandle, (uint)milliseconds) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetExitCode()
        {
            if (!Kernel32.GetExitCodeProcess(ProcessHandle, out var exitCode))
            {
                Win32.ThrowWin32Exception();
            }

            return (int)exitCode;
        }

        public void Dispose()
        {
            if (Win32.IsHandleValid(ProcessHandle))
            {
                Kernel32.CloseHandle(ProcessHandle);
            }

            if (Win32.IsHandleValid(ThreadHandle))
            {
                Kernel32.CloseHandle(ThreadHandle);
            }
        }
    }
}
