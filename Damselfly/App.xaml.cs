using Components.Aphid.Debugging;
using Damselfly.Components;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Damselfly
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DamselflyErrorReporter.Attach();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //MessageBox.Show(string.Format("{0:x8}", RenderCapability.Tier));
            //RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (!Debugger.IsAttached)
            {
                DamselflyErrorReporter.SaveError(e.Exception);
            }
        }
    }
}
