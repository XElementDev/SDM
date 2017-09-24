using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.SDM.UI.Win32.Common;

namespace XElement.SDM.UI.Win32.Modules.About
{
    [Export( typeof( IFactory<AboutWindow> ) )]
    internal class AboutWindowFactory : 
        WindowFactoryBase<AboutViewModel, AboutWindow>, IFactory<AboutWindow>
    {
        [ImportingConstructor]
        private AboutWindowFactory() : base()
        {
            this._aboutVM = null;
        }


        protected override AboutViewModel /*WindowFactoryBaseT2.*/ViewModel
        {
            get { return this._aboutVM; }
        }


        [Import]
        private AboutViewModel _aboutVM;
    }
}
