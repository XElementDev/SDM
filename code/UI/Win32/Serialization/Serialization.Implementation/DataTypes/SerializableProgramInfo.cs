using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableProgramInfo : IProgramInfo
    {
        public SerializableProgramInfo() { }

        public SerializableProgramInfo( IProgramInfo copyFrom )
        {
            var fileOrigin = copyFrom.Origin as IFileOrigin;
            var registryOrigin = copyFrom.Origin as IRegistryOrigin;
            if ( fileOrigin != null )
                this.Origin = new SerializableFileOrigin( fileOrigin );
            else if ( registryOrigin != null )
                this.Origin = new SerializableRegistryOrigin( registryOrigin );

            this.StartInfo = new SerializableStartInfo( copyFrom.StartInfo );
        }


        [XmlElement( "FileOrigin", typeof( SerializableFileOrigin ) ), 
         XmlElement( "RegistryOrigin", typeof( SerializableRegistryOrigin ) )]
        public AbstractSerializableOrigin Origin { get; set; }

        IOrigin IProgramInfo.Origin { get { return this.Origin; } }


        [XmlElement( "StartInfo" )]
        public SerializableStartInfo StartInfo { get; set; }

        IStartInfo IProgramInfo.StartInfo { get { return this.StartInfo; } }
    }
#endregion
}
