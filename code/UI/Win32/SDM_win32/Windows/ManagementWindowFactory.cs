using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32
{
    [Export( typeof( IFactory<ManagementWindow> ) )]
    internal class ManagementWindowFactory : IFactory<ManagementWindow>
    {
        [ImportingConstructor]
        private ManagementWindowFactory()
        {
            this._mainVM = null;
            this._previousMgmtWindow = null;
        }


        public ManagementWindow /*IFactoryT1.*/Get()
        {
            bool notOpenedYet = this._previousMgmtWindow == null;
            if ( notOpenedYet || this._hasWindowBeenClosed )
            {
                this._previousMgmtWindow = new ManagementWindow
                {
                    DataContext = this._mainVM
                };
                this._hasWindowBeenClosed = false;
                this._previousMgmtWindow.Closed += ( s, e ) => this._hasWindowBeenClosed = true;
            }

            return this._previousMgmtWindow;
        }


        [Import]
        private Modules.Main.ViewModel _mainVM;


        private bool _hasWindowBeenClosed;

        private ManagementWindow _previousMgmtWindow;

    }
}
