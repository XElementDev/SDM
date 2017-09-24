using System.Windows;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32.Common
{
    internal abstract class WindowFactoryBase<TViewModel, TWindow> : 
        IFactory<TWindow>
        where TWindow : Window, new()
    {
        protected WindowFactoryBase()
        {
            this._previousMgmtWindow = null;
        }


        public TWindow /*IFactoryT1.*/Get()
        {
            bool notOpenedYet = this._previousMgmtWindow == null;
            if (notOpenedYet || this._hasWindowBeenClosed)
            {
                this._previousMgmtWindow = new TWindow
                {
                    DataContext = this.ViewModel
                };
                this._hasWindowBeenClosed = false;
                this._previousMgmtWindow.Closed += ( s, e ) => this._hasWindowBeenClosed = true;
            }

            return this._previousMgmtWindow;
        }


        protected abstract TViewModel ViewModel { get; }


        private bool _hasWindowBeenClosed;

        private TWindow _previousMgmtWindow;
    }
}
