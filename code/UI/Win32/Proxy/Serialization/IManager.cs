using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
    //TODO: DRY w.r.t. CSH project
    public interface IManager
    {
        IProgramInfo Deserialize( string serialized );


        string Serialize( IProgramInfo toSerialize );
    }
}
