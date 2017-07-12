using Microsoft.Win32;
using XElement.DotNet.System.Environment.Startup.Technical;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class Local64bitRegistryRetriever : LocalRegistryRetrieverBase, IStartupInfo
    {
        public Local64bitRegistryRetriever() { }


        protected override RegistryView /*LocalRegistryRetrieverBase.*/Mode
        {
            get { return RegistryView.Registry64; }
        }
    }
#endregion
}
