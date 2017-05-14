using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup.DataTypes
{
#region not unit-tested
    internal class RegistryOrigin : IRegistryOrigin
    {
        // TODO: Implemented Location property properly. TLN must be contained. Mind also "Wow6432Node".
        public string /*IRegistryOrigin.*/Location { get { return this.SubKey; } }


        public RegistryView /*IRegistryOrigin.*/Mode { get; set; }


        public string /*IRegistryOrigin.*/SubKey { get; set; }


        public RegistryHive /*IRegistryOrigin.*/TopLevelNode { get; set; }


        public string /*IRegistryOrigin.*/ValueName { get; set; }
    }
#endregion
}
