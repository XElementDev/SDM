using GalaSoft.MvvmLight.CommandWpf;    // https://blog.jsinh.in/relay-command-canexecute-not-working-using-mvvmlight-toolkit-in-wpf/#.WQyFleXyhHY
using System;
using System.Linq;
using System.Windows.Input;
using XElement.SDM.UI.Win32.Modules.ProgramInfo;
using XElement.SDM.UI.Win32.Modules.ProgramInfos;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class ManagementViewModel
    {
        public ManagementViewModel( ManagementModel model )
        {
            this._model = model;
            this.InitializeProperties();
            this.InitializeCommands();
        }


        private ICommand CreateCommand( Action<ProgramInfo.ProgramInfoViewModel> execute, 
                                        Func<ProgramInfo.ProgramInfoViewModel, bool> canExecute )
        {
            return new RelayCommand<ProgramInfo.ProgramInfoViewModel>( execute, canExecute );
        }


        public ProgramInfosViewModel DelayedProgramInfosVM { get; private set; }


        public ICommand DelayStartupCommand { get; private set; }

        private bool DelayStartupCommand_CanExecute( ProgramInfoViewModel programInfoVM )
        {
            var startup = this.StartupProgramInfosVM.ProgramInfoVMs.ToList();
            var isStartup = startup.Contains( programInfoVM );
            return isStartup;
        }

        private void DelayStartupCommand_Execute( ProgramInfoViewModel programInfoVM )
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
            var delayed = new ProgramInfosViewModel( this._model.DelayedProgramInfosModel );
            this.DelayedProgramInfosVM = delayed;

            var startup = new ProgramInfosViewModel( this._model.StartupProgramInfosModel );
            this.StartupProgramInfosVM = startup;
        }


        public ICommand PromoteStartupCommand { get; private set; }

        private bool PromoteStartupCommand_CanExecute( ProgramInfoViewModel programInfoVM )
        {
            var delayed = this.DelayedProgramInfosVM.ProgramInfoVMs.ToList();
            var isDelayed = delayed.Contains( programInfoVM );
            return isDelayed;
        }

        private void PromoteStartupCommand_Execute( ProgramInfoViewModel programInfoVM )
        {
            var programInfo = programInfoVM.Model.ProgramInfo;
            this._model.PromoteStartup( programInfo );
        }


        public ProgramInfosViewModel StartupProgramInfosVM { get; private set; }


        private ManagementModel _model;
    }
#endregion
}
