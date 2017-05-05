using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    // TODO
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

        private void DelayStartupCommand_Execute( ProgramInfo.ViewModel programInfoVM )
        {
            var programInfo = programInfoVM.Model.ProgramInfo;
            this._model.DelayStartup( programInfo );
        }


        private void InitializeCommands()
        {
            this.DelayStartupCommand = this.CreateCommand( this.DelayStartupCommand_Execute, 
                                                           _ => true );
            this.PromoteStartupCommand = this.CreateCommand( this.PromoteStartupCommand_Execute, 
                                                             _ => true );
        }


        private void InitializeProperties()
        {
            var delayed = new ProgramInfos.ViewModel( this._model.DelayedProgramInfosModel );
            this.DelayedProgramInfosVM = delayed;

            var startup = new ProgramInfos.ViewModel( this._model.StartupProgramInfosModel );
            this.StartupProgramInfosVM = startup;
        }


        public ICommand PromoteStartupCommand { get; private set; }

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
