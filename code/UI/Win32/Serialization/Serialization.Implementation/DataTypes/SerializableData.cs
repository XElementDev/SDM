using System.Collections.Generic;
using System.Xml.Serialization;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    [XmlRoot( "Data" )]
    public class SerializableData : IData
    {
        [XmlElement( "DelayedApplicationInfo" )]
        public List<DelayedApplicationInfo> DelayedApplications { get; set; }

        IEnumerable<IDelayedApplicationInfo> IData.DelayedApplications
        {
            get { return this.DelayedApplications; }
        }
    }
#endregion
}
