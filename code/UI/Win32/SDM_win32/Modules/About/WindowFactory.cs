using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.SDM.UI.Win32.Common;

namespace XElement.SDM.UI.Win32.Modules.About
{
    [Export( typeof( IFactory<AboutWindow> ) )]
    internal class WindowFactory : 
        WindowFactoryBase<Modules.About.ViewModel, AboutWindow>, IFactory<AboutWindow>
    {
        [ImportingConstructor]
        private WindowFactory() : base()
        {
            this._aboutVM = null;
        }


        protected override Modules.About.ViewModel ViewModel
        {
            get { return this._aboutVM; }
        }


        [Import]
        private Modules.About.ViewModel _aboutVM;
    }
}
