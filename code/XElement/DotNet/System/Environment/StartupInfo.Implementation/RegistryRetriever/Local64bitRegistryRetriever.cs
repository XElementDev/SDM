using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class Local64bitRegistryRetriever : RegistryRetrieverBase, IStartupInfo
    {
        public Local64bitRegistryRetriever() { }


        protected override bool /*RegistryRetrieverBase.*/IsForAllUsers { get { return false; } }


        protected override RegistryView /*RegistryRetrieverBase.*/Mode
        {
            get { return RegistryView.Registry64; }
        }


        protected override RegistryHive /*RegistryRetrieverBase.*/TopLevelNode
        {
            get { return RegistryHive.CurrentUser; }
        }
    }
#endregion
}
