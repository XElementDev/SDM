using System.Collections.Generic;
using System.ComponentModel.Composition;
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
            this._startupInfo = null;
        }


        public Management.Model ManagementModel { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var startup = this._startupInfo.Retrieve();
            var delayed = new List<IProgramInfo>(); // TODO
            this.ManagementModel = new Management.Model( startup, delayed ); 
        }


        [Import]
        private IStartupInfo _startupInfo;
    }
#endregion
}
