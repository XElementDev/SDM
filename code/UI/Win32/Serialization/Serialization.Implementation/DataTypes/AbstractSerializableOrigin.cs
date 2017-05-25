using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public abstract class AbstractSerializableOrigin : IOrigin
    {
        public abstract string /*IOrigin.*/Location { get; set; }
    }
#endregion
}
