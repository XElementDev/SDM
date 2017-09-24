using System;
using System.Linq;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;
using XElement.SDM.UI.Win32.Modules.ProgramInfos;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class ManagementModel
    {
        public ManagementModel( ManagementModelParameters parameters, 
                                MainModelDependencies dependencies )
        {
            this._dependencies = dependencies;

            this.InitializeDelayedProgramInfosModel( parameters );
            this.InitializeStartupProgramInfosModel( parameters );

            this.SubscribeEvents();
        }


        private IProgramLogic CreateProgramLogic( IProgramInfo programInfo )
        {
            var programLogic = this._dependencies.ProgramLogicFactory.Get( programInfo );
            return programLogic;
        }


        public ProgramInfosModel DelayedProgramInfosModel { get; private set; }


        public void DelayStartup( IProgramInfo programInfo )
        {
            this.StartupProgramInfosModel.Remove( programInfo );
            var programLogic = this.CreateProgramLogic( programInfo );
            programLogic.Do();
            this.DelayedProgramInfosModel.Add( programInfo );
        }


        private void InitializeDelayedProgramInfosModel( ManagementModelParameters parameters )
        {
            var model = new ProgramInfosModel( parameters.DelayedProgramInfos );
            this.DelayedProgramInfosModel = model;
        }


        private void InitializeStartupProgramInfosModel( ManagementModelParameters parameters )
        {
            string appFilePath = this._dependencies.AppInfoAccessor.FilePath;
            Func<IProgramInfo, bool> isThisApp = pi => pi.StartInfo.FilePath == appFilePath;
            var filtered = parameters.StartupProgramInfos.Where( pi => !isThisApp( pi ) ).ToList();
            var model = new ProgramInfosModel( filtered );
            this.StartupProgramInfosModel = model;
        }


        public ProgramInfosModel StartupProgramInfosModel { get; private set; }


        public void PromoteStartup( IProgramInfo programInfo )
        {
            this.DelayedProgramInfosModel.Remove( programInfo );
            var programLogic = this.CreateProgramLogic( programInfo );
            programLogic.Undo();
            this.StartupProgramInfosModel.Add( programInfo );
        }


        private void SubscribeEvents()
        {
            this.DelayedProgramInfosModel.PropertyChanged += ( s, e ) =>
            {
                var programInfoModels = this.DelayedProgramInfosModel.ProgramInfoModels;
                var programInfos = programInfoModels.Select( m => m.ProgramInfo ).ToList();
                this._dependencies.DataContainer.DelayedApplications = programInfos;
            };
        }


        private MainModelDependencies _dependencies;
    }
#endregion
}
