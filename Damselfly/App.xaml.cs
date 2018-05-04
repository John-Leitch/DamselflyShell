using System;
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
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //MessageBox.Show(string.Format("{0:x8}", RenderCapability.Tier));
            //RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            File.WriteAllText(
                Path.Combine(
                    path,
                    string.Format("crash-{0}.log", Environment.TickCount)),
                e.Exception.ToString());
        }
    }
}
