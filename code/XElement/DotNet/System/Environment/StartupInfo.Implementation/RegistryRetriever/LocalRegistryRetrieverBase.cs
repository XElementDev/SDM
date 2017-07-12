using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public abstract class LocalRegistryRetrieverBase : RegistryRetrieverBase, IStartupInfo
    {
        public LocalRegistryRetrieverBase() { }


        protected override bool /*RegistryRetrieverBase.*/IsForAllUsers { get { return false; } }


        protected override RegistryHive /*RegistryRetrieverBase.*/TopLevelNode
        {
            get { return RegistryHive.CurrentUser; }
        }
    }
#endregion
}
