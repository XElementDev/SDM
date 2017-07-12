using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class Local32bitRegistryRetriever : LocalRegistryRetrieverBase, IStartupInfo
    {
        public Local32bitRegistryRetriever() { }


        protected override RegistryView /*LocalRegistryRetrieverBase.*/Mode
        {
            get { return RegistryView.Registry32; }
        }
    }
#endregion
}
