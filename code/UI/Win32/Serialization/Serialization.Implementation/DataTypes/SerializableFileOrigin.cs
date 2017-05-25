using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableFileOrigin : AbstractSerializableOrigin, IFileOrigin
    {
        [XmlAttribute( "location" )]
        public override string /*AbstractSerializableOrigin.*/Location { get; set; }
    }
#endregion
}
