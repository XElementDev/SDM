using System;
using System.IO;
using System.Xml.Serialization;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    public class Manager : IManager
    {
        public Manager()
        {
            this._serializer = new XmlSerializer( typeof( SerializableProxyParameters ) );
        }


        public IProxyParameters /*IManager.*/Deserialize( string serialized )
        {
            IProxyParameters deserialized = null;

            var bytes = Convert.FromBase64String( serialized );
            using (var stream = new MemoryStream( bytes ))
            {
                var deserializedObj = this._serializer.Deserialize( stream );
                deserialized = deserializedObj as IProxyParameters;
            }

            return deserialized;
        }


        public string /*IManager.*/Serialize( IProxyParameters toSerialize )
        {
            string serialized = null;

            var serializableProxyParams = new SerializableProxyParameters( toSerialize );
            using ( var stream = new MemoryStream() )
            {
                this._serializer.Serialize( stream, serializableProxyParams );
                var bytes = stream.ToArray();
                serialized = Convert.ToBase64String( bytes );
            }

            return serialized;
        }


        private XmlSerializer _serializer;
    }
#endregion
}
