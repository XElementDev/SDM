using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
    public interface IManager
    {
        IProgramInfo Deserialize( string serialized );


        string Serialize( IProgramInfo toSerialize );
    }
}
