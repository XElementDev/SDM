using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Serialization.DataTypes
{
#region not unit-tested
    public class SerializableFileOrigin : AbstractSerializableOrigin, IFileOrigin
    {
        public SerializableFileOrigin() { }

        public SerializableFileOrigin( IFileOrigin copyFrom )
        {
            this.Location = copyFrom.Location;
        }
    }
#endregion
}
