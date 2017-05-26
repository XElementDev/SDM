using System.Collections.Generic;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Serialization;

namespace XElement.SDM.UI.Win32.Model.Serialization
{
#region not unit-tested
    internal class Data : IData
    {
        public IEnumerable<IProgramInfo> /*IData.*/DelayedApplications { get; set; }
    }
#endregion
}
