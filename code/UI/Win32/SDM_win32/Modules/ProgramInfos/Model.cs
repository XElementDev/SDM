using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
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


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var programInfos = this._startupInfo.Retrieve();
            this.ProgramInfos = programInfos;
        }


        public IEnumerable<IProgramInfo> ProgramInfos { get; private set; }


        [Import]
        private IStartupInfo _startupInfo;
    }
#endregion
}
