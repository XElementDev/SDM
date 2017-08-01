using Microsoft.Practices.Prism.Events;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Windows;
using XElement.SDM.UI.Win32.Model.Events;

namespace XElement.SDM.UI.Win32.Bootstrapping
{
#region not unit-tested
    internal class Bootstrapper
    {
        public Bootstrapper()
        {
            this._eventAggregator = null;
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
            container.ComposeExportedValue<IEventAggregator>( new EventAggregator() );

            container.ComposeParts( this );
        }


        private void RaiseApplicationClosingEvent()
        {
            var appClosingEvent = this._eventAggregator.GetEvent<ApplicationClosing>();
            appClosingEvent.Publish( "irrelevant" );
        }


        public void Run()
        {
            this.InitializeMef();
            this.ShowTaskbarIcon();
            this.SubscribeEvents();
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


        private void SubscribeEvents()
        {
            var app = Application.Current;
            app.MainWindow.Closed += ( s, e ) => this.RaiseApplicationClosingEvent();
        }


        [Import]
        private IEventAggregator _eventAggregator;

        [Import]
        private Modules.TaskbarIcon.ViewModel _taskbarIconVM = null;
    }
#endregion
}
