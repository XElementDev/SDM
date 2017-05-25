using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableProgramInfo : IProgramInfo
    {
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
