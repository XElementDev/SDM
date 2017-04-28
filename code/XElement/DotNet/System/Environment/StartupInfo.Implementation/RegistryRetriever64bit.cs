using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class RegistryRetriever64bit : RegistryRetrieverBase, IStartupInfo
    {
        public RegistryRetriever64bit() { }


        protected override RegistryView Mode { get { return RegistryView.Registry64; } }
    }
#endregion
}
