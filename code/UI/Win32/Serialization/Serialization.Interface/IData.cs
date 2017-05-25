using System.Collections.Generic;

namespace XElement.SDM.UI.Win32.Serialization
{
    //  --> TODO: find better name
    public interface IData
    {
        IEnumerable<IDelayedApplicationInfo> DelayedApplications { get; }
    }
}
