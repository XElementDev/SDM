using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using XElement.SDM.UI.Win32.Serialization.DataTypes;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    public class Manager : IManager
    {
        public Manager()
        {
            this._formatter = new BinaryFormatter();
        }


        public IProxyParameters /*IManager.*/Deserialize( string serialized )
        {
            IProxyParameters deserialized = null;

            var bytes = Convert.FromBase64String( serialized );
            using (var stream = new MemoryStream( bytes ))
            {
                var deserializedObj = this._formatter.Deserialize( stream );
                deserialized = deserializedObj as IProxyParameters;
            }

            return deserialized;
        }


        public string /*IManager.*/Serialize( IProxyParameters toSerialize )
        {
            var serialized = this.Serialize( new SerializableProxyParameters( toSerialize ) );
            return serialized;
        }

        private string Serialize( SerializableProgramInfo toSerialize )
        {
            string serialized = null;

            using ( var stream = new MemoryStream() )
            {
                this._formatter.Serialize( stream, toSerialize );
                var bytes = stream.ToArray();
                serialized = Convert.ToBase64String( bytes );
            }

            return serialized;
        }


        private IFormatter _formatter;
    }
#endregion
}
