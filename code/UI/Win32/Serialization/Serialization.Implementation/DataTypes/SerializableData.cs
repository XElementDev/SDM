using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    [XmlRoot( "Data" )]
    public class SerializableData : IData
    {
        [XmlElement( "DelayedApplications" )]
        //public List<SerializableDelayedApplicationInfo> DelayedApplications { get; set; }
        public List<SerializableProgramInfo> DelayedApplications { get; set; }

        //IEnumerable<IDelayedApplicationInfo> IData.DelayedApplications
        //{
        //    get { return this.DelayedApplications; }
        //}
        IEnumerable<IProgramInfo> IData.DelayedApplications
        {
            get { return this.DelayedApplications; }
        }
    }
#endregion
}
