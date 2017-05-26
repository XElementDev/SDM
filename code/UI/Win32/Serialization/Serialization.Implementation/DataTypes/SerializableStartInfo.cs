using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableStartInfo : IStartInfo
    {
        public SerializableStartInfo() { }

        public SerializableStartInfo( IStartInfo copyFrom )
        {
            this.Arguments = copyFrom.Arguments;
            this.FilePath = copyFrom.FilePath;
        }


        [XmlAttribute( "arguments" )]
        public string Arguments { get; set; }


        [XmlAttribute( "filePath" )]
        public string FilePath { get; set; }
    }
#endregion
}
