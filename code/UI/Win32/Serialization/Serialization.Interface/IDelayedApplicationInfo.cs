using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.DelayLogic;

namespace XElement.SDM.UI.Win32.Serialization
{
    public interface IDelayedApplicationInfo
    {
        IDelayInfo DelayInfo { get; }


        IOrigin Origin { get; }
    }
}
