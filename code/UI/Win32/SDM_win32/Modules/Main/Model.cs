using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class Model : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public Model()
        {
            this._managementModelFactory = null;
            this._startupInfo = null;
        }


        public Management.Model ManagementModel { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var mgmtParams = new Management.ModelParameters
            {
                DelayedProgramInfos = new List<IProgramInfo>(), // TODO
                StartupProgramInfos = this._startupInfo.Retrieve()
            };
            var mgmtModel = this._managementModelFactory.Get( mgmtParams );
            this.ManagementModel = mgmtModel;
        }


        [Import]

        private IFactory<Management.Model, Management.ModelParameters> _managementModelFactory = null;

        [Import]
        private IStartupInfo _startupInfo = null;
    }
#endregion
}
