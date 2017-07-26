using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Windows;

namespace XElement.SDM.UI.Win32.Bootstrapping
{
#region not unit-tested
    internal class Bootstrapper
    {
        public Bootstrapper()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }


        private ComposablePartCatalog CreateCatalog()
        {
            var catalog = new AggregateCatalog();
            var assembly = typeof( App ).Assembly;
            string path = Path.GetDirectoryName( assembly.Location );
            catalog.Catalogs.Add( new AggregateCatalog( new AssemblyCatalog( assembly ),
                                                        new DirectoryCatalog( path ) ) );
            return catalog;
        }


        private void InitializeMef()
        {
            var catalog = this.CreateCatalog();
            var container = new CompositionContainer( catalog );

            container.ComposeParts( this );
        }


        public void Run()
        {
            this.InitializeMef();
            this.ShowTaskbarIcon();
        }


        private void ShowTaskbarIcon()
        {
            var app = Application.Current;
            app.MainWindow = new TaskbarIconWindow
            {
                DataContext = this._taskbarIconVM
            };
            app.MainWindow.Show();
        }


        [Import]
        private Modules.TaskbarIcon.ViewModel _taskbarIconVM = null;
    }
#endregion
}
