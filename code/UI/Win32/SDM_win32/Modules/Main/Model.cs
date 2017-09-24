using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Model;
using XElement.SDM.UI.Win32.Modules.Management;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class MainModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public MainModel( MainModelDependencies dependencies )
        {
            this._dependencies = dependencies;

            this._dataContainer = null;
            this._managementModelFactory = null;
            this._startupInfo = null;
        }


        public ManagementModel ManagementModel { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var mgmtParams = new ManagementModelParameters
            {
                DelayedProgramInfos = this._dataContainer.DelayedApplications, 
                StartupProgramInfos = this._startupInfo.Retrieve()
            };
            var mgmtModel = this._managementModelFactory.Get( mgmtParams );
            this.ManagementModel = mgmtModel;
        }


        [Import]
        private DataContainer _dataContainer;

        [Import]
        private IFactory<ManagementModel, ManagementModelParameters> _managementModelFactory;

        [Import]
        private IStartupInfo _startupInfo;


        private MainModelDependencies _dependencies;
    }
#endregion
}
