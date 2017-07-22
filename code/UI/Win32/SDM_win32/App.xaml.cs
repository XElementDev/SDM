using System.Windows;

namespace XElement.SDM.UI.Win32
{
#region not unit-tested
    public partial class App : Application
    {
        public App() { }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new Bootstrapper().Run();
        }
    }
#endregion
}
