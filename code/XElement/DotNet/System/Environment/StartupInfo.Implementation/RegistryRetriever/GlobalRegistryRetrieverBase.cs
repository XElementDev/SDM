using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup.Technical
{
#region not unit-tested
    public abstract class GlobalRegistryRetrieverBase : RegistryRetrieverBase, IStartupInfo
    {
        public GlobalRegistryRetrieverBase() { }


        protected override bool /*RegistryRetrieverBase.*/IsForAllUsers { get { return true; } }


        protected override RegistryHive /*RegistryRetrieverBase.*/TopLevelNode
        {
            get { return RegistryHive.LocalMachine; }
        }
    }
#endregion
}
