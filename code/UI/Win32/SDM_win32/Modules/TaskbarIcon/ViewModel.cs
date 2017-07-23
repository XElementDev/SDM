using GalaSoft.MvvmLight.Command;
using System.ComponentModel.Composition;
using System.Windows.Input;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32.Modules.TaskbarIcon
{
#region not unit-tested
    [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        private ViewModel()
        {
            this.InitializeCommands();
        }


        public ICommand ExitApplicationCommand { get; private set; }

        private void ExitApplicationCommand_Execute()
        {
            this._model.ExitApplication();
        }


        private void InitializeCommands()
        {
            this.ExitApplicationCommand = new RelayCommand( this.ExitApplicationCommand_Execute );
            this.ShowWindowCommand = new RelayCommand( this.ShowWindowCommand_Execute );
        }


        public ICommand ShowWindowCommand { get; private set; }

        private void ShowWindowCommand_Execute()
        {
            var mgmtWindow = this._mgmtWindowFactory.Get();
            mgmtWindow.Show();
        }


        [Import]
        private IFactory<ManagementWindow> _mgmtWindowFactory = null;

        [Import]
        private Modules.TaskbarIcon.Model _model = null;
    }
#endregion
}
