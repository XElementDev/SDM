using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.DelayLogic;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableDelayedApplicationInfo : IDelayedApplicationInfo
    {
        [XmlElement( "DelayInfo" )]
        public SerializableDelayInfo DelayInfo { get; set; }

        IDelayInfo IDelayedApplicationInfo.DelayInfo
        {
            get { return this.DelayInfo; }
        }


        //  --> TODO
        //[XmlElement( "FileOrigin", typeof( SerializableFileOrigin ) ), 
        // XmlElement( "RegistryOrigin", typeof( SerializableRegistryOrigin ) )]
        //public IOrigin Origin { get; set; }

        [XmlIgnore]
        IOrigin IDelayedApplicationInfo.Origin => null;
    }
#endregion
}
