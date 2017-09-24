using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Model;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class Model : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public Model( ModelDependencies dependencies )
        {
            this._dependencies = dependencies;
            this._managementModelFactory = null;
            this._startupInfo = null;
        }


        public Management.Model ManagementModel { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var mgmtParams = new Management.ModelParameters
            {
                DelayedProgramInfos = this._dataContainer.DelayedApplications, 
                StartupProgramInfos = this._startupInfo.Retrieve()
            };
            var mgmtModel = this._managementModelFactory.Get( mgmtParams );
            this.ManagementModel = mgmtModel;
        }


        [Import]
        private DataContainer _dataContainer = null;

        [Import]
        private IFactory<Management.Model, Management.ModelParameters> _managementModelFactory = null;

        [Import]
        private IStartupInfo _startupInfo = null;


        private ModelDependencies _dependencies;
    }
#endregion
}
