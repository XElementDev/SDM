using System.Windows;

namespace XElement.SDM.UI.Win32.Bootstrapping
{
#region not unit-tested
    public partial class App : Application
    {
        public App()
        {
            this.Startup += ( s, e ) =>
            {
                new Bootstrapper().Run();
            };
        }
    }
#endregion
}
