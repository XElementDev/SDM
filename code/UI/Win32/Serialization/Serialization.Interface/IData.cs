using System.Collections.Generic;

namespace XElement.SDM.UI.Win32.Serialization
{
    public interface IData
    {
        IEnumerable<IDelayedApplicationInfo> DelayedApplications { get; }
    }
}
