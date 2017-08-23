using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
    public interface IProxyParameters
    {
        CommandMethod CommandMethod { get; }


        IProgramInfo ProgramInfo { get; }
    }
}
