using Microsoft.Win32;
using System;
using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableRegistryOrigin : IRegistryOrigin
    {
        [XmlIgnore]
        string IOrigin.Location => null;


        [XmlAttribute( "mode" )]
        public string Mode { get; set; }

        RegistryView IRegistryOrigin.Mode
        {
            get
            {
                var parsed = Enum.Parse( typeof( RegistryView ), this.Mode );
                return (RegistryView)parsed;
            }
        }


        [XmlAttribute( "subKey" )]
        public string SubKey { get; set; }


        [XmlAttribute( "tln" )]
        public string TopLevelNode { get; set; }

        RegistryHive IRegistryOrigin.TopLevelNode
        {
            get
            {
                var parsed = Enum.Parse( typeof( RegistryHive ), this.TopLevelNode );
                return (RegistryHive)parsed;
            }
        }


        [XmlAttribute( "valueName" )]
        public string ValueName { get; set; }
    }
#endregion
}
