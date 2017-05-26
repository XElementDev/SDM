using System.Linq;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class Model
    {
        public Model( ModelParameters parameters, ModelDependencies dependencies )
        {
            this._dependencies = dependencies;

            var delayed = new ProgramInfos.Model( parameters.DelayedProgramInfos );
            this.DelayedProgramInfosModel = delayed;

            var startup = new ProgramInfos.Model( parameters.StartupProgramInfos );
            this.StartupProgramInfosModel = startup;

            this.SubscribeEvents();
        }


        private IProgramLogic CreateProgramLogic( IProgramInfo programInfo )
        {
            var programLogic = this._dependencies.ProgramLogicFactory.Get( programInfo );
            return programLogic;
        }


        public ProgramInfos.Model DelayedProgramInfosModel { get; private set; }


        public void DelayStartup( IProgramInfo programInfo )
        {
            this.StartupProgramInfosModel.Remove( programInfo );
            var programLogic = this.CreateProgramLogic( programInfo );
            programLogic.Do();
            this.DelayedProgramInfosModel.Add( programInfo );
        }


        public ProgramInfos.Model StartupProgramInfosModel { get; private set; }


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


        private ModelDependencies _dependencies;
    }
#endregion
}
