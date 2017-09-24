using GalaSoft.MvvmLight.Command;
using System.ComponentModel.Composition;
using System.Windows;
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
            this._aboutWindowFactory = null;
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
            this.ShowAboutWindowCommand = new RelayCommand( this.ShowAboutWindowCommand_Execute );
            this.ShowWindowCommand = new RelayCommand( this.ShowWindowCommand_Execute );
        }


        public ICommand ShowAboutWindowCommand { get; private set; }

        private void ShowAboutWindowCommand_Execute()
        {
            this.ShowUsing( this._aboutWindowFactory );
        }


        private void ShowUsing<TWindow>( IFactory<TWindow> windowFactory ) where TWindow : Window
        {
            var window = windowFactory.Get();
            if( window.IsVisible )
            {
                window.Activate();
            }
            else
            {
                window.Show();
            }
        }


        public ICommand ShowWindowCommand { get; private set; }

        private void ShowWindowCommand_Execute()
        {
            this.ShowUsing( this._mgmtWindowFactory );
        }


        [Import]
        private IFactory<AboutWindow> _aboutWindowFactory;

        [Import]
        private IFactory<ManagementWindow> _mgmtWindowFactory = null;

        [Import]
        private Modules.TaskbarIcon.Model _model = null;
    }
#endregion
}
