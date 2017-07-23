using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32
{
#region not unit-tested
    [Export( typeof( IFactory<ManagementWindow> ) )]
    internal class ManagementWindowFactory : IFactory<ManagementWindow>
    {
        [ImportingConstructor]
        private ManagementWindowFactory() { }


        public ManagementWindow /*IFactoryT1.*/Get()
        {
            var mgmtWindow = new ManagementWindow();
            mgmtWindow.DataContext = this._mainVM;
            return mgmtWindow;
        }


        [Import]
        private Modules.Main.ViewModel _mainVM = null;
    }
#endregion
}
