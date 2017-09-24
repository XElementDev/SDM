using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.SDM.UI.Win32.Common;
using XElement.SDM.UI.Win32.Modules.Main;

namespace XElement.SDM.UI.Win32
{
    [Export( typeof( IFactory<ManagementWindow> ) )]
    internal class ManagementWindowFactory : 
        WindowFactoryBase<MainViewModel, ManagementWindow>, IFactory<ManagementWindow>
    {
        [ImportingConstructor]
        private ManagementWindowFactory() : base()
        {
            this._mainVM = null;
        }


        protected override MainViewModel /*WindowFactoryBaseT2.*/ViewModel
        {
            get { return this._mainVM; }
        }


        [Import]
        private MainViewModel _mainVM;

    }
}
