using XElement.SDM.UI.Win32.Proxy.Serialization;
using IProxySerializationManager = XElement.SDM.UI.Win32.Proxy.Serialization.IManager;
using ProxySerializationManager = XElement.SDM.UI.Win32.Proxy.Serialization.Manager;

namespace XElement.SDM.UI.Win32.Proxy.Logic
{
#region not unit-tested
    internal class MessageParser
    {
        public MessageParser()
        {
            this._serializationManager = new ProxySerializationManager();
        }


        public IProxyParameters Parse( string serialized )
        {
            IProxyParameters deserialized = null;

            if ( serialized != null )
            {
                deserialized = this._serializationManager.Deserialize( serialized );
            }

            return deserialized;
        }


        private IProxySerializationManager _serializationManager;
    }
#endregion
}
