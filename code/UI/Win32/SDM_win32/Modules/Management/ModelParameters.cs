using System.Collections.Generic;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class ManagementModelParameters
    {
        public ManagementModelParameters() { }


        public IEnumerable<IProgramInfo> DelayedProgramInfos { get; set; }


        public IEnumerable<IProgramInfo> StartupProgramInfos { get; set; }
    }
#endregion
}
