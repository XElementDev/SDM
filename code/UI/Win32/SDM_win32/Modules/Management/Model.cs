using System.Collections.Generic;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class Model
    {
        public Model( IEnumerable<IProgramInfo> startupProgramInfos, 
                      IEnumerable<IProgramInfo> delayedProgramInfos )
        {
            this.DelayedProgramInfosModel = new ProgramInfos.Model( delayedProgramInfos );
            this.StartupProgramInfosModel = new ProgramInfos.Model( startupProgramInfos );
        }


        public ProgramInfos.Model DelayedProgramInfosModel { get; private set; }


        public ProgramInfos.Model StartupProgramInfosModel { get; private set; }
    }
#endregion
}
