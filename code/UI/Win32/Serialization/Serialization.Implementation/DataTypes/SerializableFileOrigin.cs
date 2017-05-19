using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableFileOrigin : IFileOrigin
    {
        [XmlAttribute( "location" )]
        public string Location { get; set; }
    }
#endregion
}
