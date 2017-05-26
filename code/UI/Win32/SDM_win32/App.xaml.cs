using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Windows;

namespace XElement.SDM.UI.Win32
{
#region not unit-tested
    public partial class App : Application
    {
        public App()
        {
            this.InitializeMef();

            this.MainWindow = new MainWindow { DataContext = this._mainVM };
            this.MainWindow.Show();
        }


        private ComposablePartCatalog CreateCatalog()
        {
            var catalog = new AggregateCatalog();
            var assembly = typeof( App ).Assembly;
            var path = Path.GetDirectoryName( assembly.Location );
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


        [Import]
        private Modules.Main.ViewModel _mainVM = null;
    }
#endregion
}
