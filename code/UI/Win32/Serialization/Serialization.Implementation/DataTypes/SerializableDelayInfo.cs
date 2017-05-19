using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.DelayLogic;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableDelayInfo : IDelayInfo
    {
        [XmlElement( "Delay" )]
        public int DelayInMinutes { get; set; }


        [XmlElement( "StartInfo" )]
        public SerializableStartInfo StartInfo { get; set; }

        IStartInfo IDelayInfo.StartInfo { get { return this.StartInfo; } }
    }
#endregion
}
