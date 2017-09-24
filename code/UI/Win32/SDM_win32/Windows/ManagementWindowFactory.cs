using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.SDM.UI.Win32.Common;

namespace XElement.SDM.UI.Win32
{
    [Export( typeof( IFactory<ManagementWindow> ) )]
    internal class ManagementWindowFactory : 
        WindowFactoryBase<Modules.Main.ViewModel, ManagementWindow>, IFactory<ManagementWindow>
    {
        [ImportingConstructor]
        private ManagementWindowFactory() : base()
        {
            this._mainVM = null;
        }


        protected override Modules.Main.ViewModel ViewModel
        {
            get { return this._mainVM; }
        }


        [Import]
        private Modules.Main.ViewModel _mainVM;

    }
}
