using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32
{
#region not unit-tested
    [Export( typeof( IFactory<MainWindow> ) )]
    internal class MainWindowFactory : IFactory<MainWindow>
    {
        [ImportingConstructor]
        private MainWindowFactory() { }


        public MainWindow /*IFactoryT1.*/Get()
        {
            var mainWindow = new MainWindow();
            mainWindow.DataContext = this._mainVM;
            return mainWindow;
        }


        [Import]
        private Modules.Main.ViewModel _mainVM = null;
    }
#endregion
}
