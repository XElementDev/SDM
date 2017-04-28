using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class RegistryRetriever32bit : RegistryRetrieverBase, IStartupInfo
    {
        public RegistryRetriever32bit() { }


        protected override RegistryView Mode { get { return RegistryView.Registry32; } }
    }
#endregion
}
