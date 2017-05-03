using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class Global32bitRegistryRetriever : RegistryRetrieverBase, IStartupInfo
    {
        public Global32bitRegistryRetriever() { }


        protected override RegistryView /*RegistryRetrieverBase.*/Mode
        {
            get { return RegistryView.Registry32; }
        }


        protected override RegistryHive /*RegistryRetrieverBase.*/TopLevelNode
        {
            get { return RegistryHive.LocalMachine; }
        }
    }
#endregion
}
