using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public abstract class AbstractSerializableOrigin : IOrigin
    {
        [XmlAttribute( "isForAllUsers" )]
        public bool /*IOrigin.*/IsForAllUsers { get; set; }


        [XmlAttribute( "location" )]
        public virtual string /*IOrigin.*/Location { get; set; }
    }
#endregion
}
