using Microsoft.Win32;
using System;
using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableRegistryOrigin : AbstractSerializableOrigin, IRegistryOrigin
    {
        public SerializableRegistryOrigin() { }

        public SerializableRegistryOrigin( IRegistryOrigin copyFrom )
        {
            this.Mode = GetStringFromEnum( copyFrom.Mode );
            this.SubKey = copyFrom.SubKey;
            this.TopLevelNode = GetStringFromEnum( copyFrom.TopLevelNode );
            this.ValueName = copyFrom.ValueName;
        }


        private static string GetStringFromEnum<T>( T value ) where T : struct, IConvertible
        {
            if ( !typeof( T ).IsEnum )
            {
                throw new ArgumentException();
            }
            return Enum.GetName( typeof( T ), value );
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
