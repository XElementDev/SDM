using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
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
            var programInfoModels = programInfos.Select( pi => new ProgramInfo.Model( pi ) )
                .ToList();
            this.ProgramInfoModels = programInfoModels;
        }


        public IEnumerable<ProgramInfo.Model> ProgramInfoModels { get; private set; }


        [Import]
        private IStartupInfo _startupInfo;
    }
#endregion
}
