using Hardcodet.Wpf.TaskbarNotification;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Windows;

namespace XElement.SDM.UI.Win32
{
#region not unit-tested
    internal class Bootstrapper
    {
        public Bootstrapper() { }


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
            this.ShowMainWindow();
            this.ShowTaskbarIcon();
        }


        private void ShowMainWindow()
        {
            var app = Application.Current;
            app.MainWindow = new MainWindow { DataContext = this._mainVM };
            app.MainWindow.Show();
        }


        private void ShowTaskbarIcon()
        {
            var app = Application.Current;
            var taskbarIcon = (TaskbarIcon)app.FindResource( "TaskbarIconControl" );
            taskbarIcon.DataContext = this._mainVM.TaskbarIconVM;
        }


        [Import]
        private Modules.Main.ViewModel _mainVM = null;
    }
#endregion
}
