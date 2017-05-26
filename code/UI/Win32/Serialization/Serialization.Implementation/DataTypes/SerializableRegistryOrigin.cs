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


        //  --> https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
        private static T GetEnumFromString<T>( string toParse ) where T : struct, IConvertible
        {
            if ( !typeof( T ).IsEnum )
            {
                throw new ArgumentException();
            }
            var parsed = Enum.Parse( typeof( T ), toParse );
            return (T)parsed;
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
            get { return GetEnumFromString<RegistryView>( this.Mode ); }
        }


        [XmlAttribute( "subKey" )]
        public string SubKey { get; set; }


        [XmlAttribute( "tln" )]
        public string TopLevelNode { get; set; }

        RegistryHive IRegistryOrigin.TopLevelNode
        {
            get { return GetEnumFromString<RegistryHive>( this.TopLevelNode ); }
        }


        [XmlAttribute( "valueName" )]
        public string ValueName { get; set; }
    }
#endregion
}
