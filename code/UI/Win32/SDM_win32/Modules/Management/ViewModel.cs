using GalaSoft.MvvmLight.Command;
using System;
using System.Linq;
using System.Windows.Input;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this._model = model;
            this.InitializeProperties();
            this.InitializeCommands();
        }


        private ICommand CreateCommand( Action<ProgramInfo.ViewModel> execute, 
                                        Func<ProgramInfo.ViewModel, bool> canExecute )
        {
            return new RelayCommand<ProgramInfo.ViewModel>( execute, canExecute );
        }


        public ProgramInfos.ViewModel DelayedProgramInfosVM { get; private set; }


        public ICommand DelayStartupCommand { get; private set; }

        private bool DelayStartupCommand_CanExecute( ProgramInfo.ViewModel programInfoVM )
        {
            var startup = this.StartupProgramInfosVM.ProgramInfoVMs.ToList();
            var isStartup = startup.Contains( programInfoVM );
            return isStartup;
        }

        private void DelayStartupCommand_Execute( ProgramInfo.ViewModel programInfoVM )
        {
            var programInfo = programInfoVM.Model.ProgramInfo;
            this._model.DelayStartup( programInfo );
        }


        private void InitializeCommands()
        {
            this.DelayStartupCommand = this.CreateCommand( this.DelayStartupCommand_Execute, 
                                                           this.DelayStartupCommand_CanExecute );
            this.PromoteStartupCommand = this.CreateCommand( this.PromoteStartupCommand_Execute, 
                                                             this.PromoteStartupCommand_CanExecute );
        }


        private void InitializeProperties()
        {
            var delayed = new ProgramInfos.ViewModel( this._model.DelayedProgramInfosModel );
            this.DelayedProgramInfosVM = delayed;

            var startup = new ProgramInfos.ViewModel( this._model.StartupProgramInfosModel );
            this.StartupProgramInfosVM = startup;
        }


        public ICommand PromoteStartupCommand { get; private set; }

        private bool PromoteStartupCommand_CanExecute( ProgramInfo.ViewModel programInfoVM )
        {
            var delayed = this.DelayedProgramInfosVM.ProgramInfoVMs.ToList();
            var isDelayed = delayed.Contains( programInfoVM );
            return isDelayed;
        }

        private void PromoteStartupCommand_Execute( ProgramInfo.ViewModel programInfoVM )
        {
            var programInfo = programInfoVM.Model.ProgramInfo;
            this._model.PromoteStartup( programInfo );
        }


        public ProgramInfos.ViewModel StartupProgramInfosVM { get; private set; }


        private Model _model;
    }
#endregion
}
