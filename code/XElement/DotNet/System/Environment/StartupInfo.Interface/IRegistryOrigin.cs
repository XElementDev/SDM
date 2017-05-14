using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
    public interface IRegistryOrigin : IOrigin
    {
        RegistryView Mode { get; }


        string SubKey { get; }


        RegistryHive TopLevelNode { get; }


        string ValueName { get; }
    }
}
