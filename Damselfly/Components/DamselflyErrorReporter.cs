using Components.Aphid.Debugging;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Damselfly.Components
{
    public static class DamselflyErrorReporter
    {
        public static DateTime AttachTime { get; private set; }

        public static void Attach()
        {
            if (!Debugger.IsAttached)
            {
                AttachTime = DateTime.Now;
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e) =>
            SaveError((Exception)(e.ExceptionObject ?? new Exception("Unknown exception")));

        public static void SaveError(Exception exception)
        {
            var runTime = DateTime.Now - AttachTime;
            var shouldRestart = runTime > TimeSpan.FromSeconds(10);
            var dmp = AphidMemoryDump.Create();
            var log = Path.ChangeExtension(dmp, "log");
            File.WriteAllText(log, exception.ToString());

            MessageBox.Show(
                string.Format(
                    "Exception: {0}\r\n\r\n" +
                    "Message: {1}\r\n\r\n" +
                    "Log: {2}\r\n\r\n" +
                    "Dump: {3}",
                    exception.GetType().Name,
                    exception.Message,
                    log,
                    dmp),
                string.Format(
                    "Fatal Error: Unhandled {0}",
                    exception.GetType().Name),
                MessageBoxButton.OK,
                MessageBoxImage.Exclamation);

            if (shouldRestart)
            {
                Process.Start(Assembly.GetEntryAssembly().Location);
            }

            Environment.Exit(0xbad80);
        }
    }
}
