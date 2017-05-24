using System.IO;
using System.Xml.Serialization;
using XElement.SDM.UI.Win32.Serialization.DataTypes;

namespace XElement.SDM.UI.Win32.Serialization
{
#region not unit-tested
    public class SerializationManager : ISerializationManager
    {
        public SerializationManager( string filePath )
        {
            this.FilePath = filePath;
            this._serializer = new XmlSerializer( typeof( SerializableData ) );
        }


        public IData /*ISerializationManager.*/Deserialize()
        {
            IData deserialized = null;

            using ( Stream fileStream = this.GetFileStream( FileMode.Open ) )
            {
                var obj = this._serializer.Deserialize( fileStream );
                deserialized = obj as IData;
            }

            return deserialized;
        }


        public string /*ISerializationManager.*/FilePath { get; private set; }


        private Stream GetFileStream( FileMode mode )
        {
            return File.Open( this.FilePath, mode );
        }


        public void /*ISerializationManager.*/Serialize( IData target )
        {
            using ( Stream fileStream = this.GetFileStream( FileMode.Create ) )
            {
                this._serializer.Serialize( fileStream, target );
            }
        }


        private XmlSerializer _serializer;
    }
#endregion
}
