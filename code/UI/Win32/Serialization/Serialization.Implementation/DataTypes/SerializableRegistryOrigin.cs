using Microsoft.Win32;
using System.Xml.Serialization;
using XElement.DotNet.System;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableRegistryOrigin : AbstractSerializableOrigin, IRegistryOrigin
    {
        public SerializableRegistryOrigin() : base() { }

        public SerializableRegistryOrigin( IRegistryOrigin copyFrom ) : base( copyFrom )
        {
            this.Mode = EnumHelper.GetStringFromEnum( copyFrom.Mode );
            this.SubKey = copyFrom.SubKey;
            this.TopLevelNode = EnumHelper.GetStringFromEnum( copyFrom.TopLevelNode );
            this.ValueName = copyFrom.ValueName;
        }


        //  --> TODO: Find better way to implement this.
        [XmlAttribute( "location" )]
        public override string /*AbstractSerializableOrigin*/Location
        {
            get { return null; }
            set { }
        }


        [XmlAttribute( "mode" )]
        public string Mode { get; set; }

        RegistryView IRegistryOrigin.Mode
        {
            get { return EnumHelper.GetEnumFromString<RegistryView>( this.Mode ); }
        }


        [XmlAttribute( "subKey" )]
        public string SubKey { get; set; }


        [XmlAttribute( "tln" )]
        public string TopLevelNode { get; set; }

        RegistryHive IRegistryOrigin.TopLevelNode
        {
            get { return EnumHelper.GetEnumFromString<RegistryHive>( this.TopLevelNode ); }
        }


        [XmlAttribute( "valueName" )]
        public string ValueName { get; set; }
    }
#endregion
}
