namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
    //TODO: DRY w.r.t. CSH project
    public interface IManager
    {
        IProxyParameters Deserialize( string serialized );


        string Serialize( IProxyParameters toSerialize );
    }
}
