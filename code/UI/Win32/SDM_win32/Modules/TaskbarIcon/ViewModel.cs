using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace XElement.SDM.UI.Win32.Modules.TaskbarIcon
{
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel()
        {
            this.InitializeCommands();
        }


        private void InitializeCommands()
        {
            this.ShowWindowCommand = new RelayCommand( this.ShowWindowCommand_Execute );
        }


        public ICommand ShowWindowCommand { get; private set; }

        private void ShowWindowCommand_Execute()
        {
            var app = Application.Current;
            app.MainWindow.Show();
        }
    }
#endregion
}
