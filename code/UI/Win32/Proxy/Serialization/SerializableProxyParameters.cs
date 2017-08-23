using System;
using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Serialization.DataTypes;

namespace XElement.SDM.UI.Win32.Proxy.Serialization
{
#region not unit-tested
    internal class SerializableProxyParameters : IProxyParameters
    {
        public SerializableProxyParameters() { }

        public SerializableProxyParameters( IProxyParameters copyFrom )
        {
            this.CommandMethod = Enum.GetName( typeof( CommandMethod ), copyFrom.CommandMethod );
            this.ProgramInfo = new SerializableProgramInfo( copyFrom.ProgramInfo );
        }


        [XmlElement( "CommandMethod" )]
        public string CommandMethod { get; set; }

        CommandMethod IProxyParameters.CommandMethod
        {
            get { return (CommandMethod)Enum.Parse( typeof( CommandMethod ), this.CommandMethod ); }
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
