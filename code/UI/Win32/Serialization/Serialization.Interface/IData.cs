using System.Collections.Generic;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization
{
    //  --> TODO: find better name
    public interface IData
    {
        //IEnumerable<IDelayedApplicationInfo> DelayedApplications { get; }
        IEnumerable<IProgramInfo> DelayedApplications { get; }
    }
}
