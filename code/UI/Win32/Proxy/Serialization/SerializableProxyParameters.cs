using System.Xml.Serialization;
using XElement.DotNet.System;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Serialization.DataTypes;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
#region not unit-tested
    [XmlRoot( "ProxyParameters" )]
    public class SerializableProxyParameters : IProxyParameters
    {
        public SerializableProxyParameters() { }

        public SerializableProxyParameters( IProxyParameters copyFrom )
        {
            this.CommandMethod = EnumHelper.GetStringFromEnum( copyFrom.CommandMethod );
            this.ProgramInfo = new SerializableProgramInfo( copyFrom.ProgramInfo );
        }


        [XmlElement( "CommandMethod" )]
        public string CommandMethod { get; set; }

        CommandMethod IProxyParameters.CommandMethod
        {
            get { return EnumHelper.GetEnumFromString<CommandMethod>( this.CommandMethod ); }
        }


        [XmlElement( "ProgramInfo" )]
        public SerializableProgramInfo ProgramInfo { get; set; }

        IProgramInfo IProxyParameters.ProgramInfo
        {
            get { return this.ProgramInfo; }
        }
    }
#endregion
}
