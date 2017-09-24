using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Reflection;

namespace XElement.SDM.UI.Win32.Modules.About
{
#region not unit-tested
    [Export]
    internal class AboutModel
    {
        [ImportingConstructor]
        private AboutModel()
        {
            this.InitializeAssemblyInfos();
        }


        public string Copyright { get; private set; }


        private void InitializeAssemblyInfos()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var versionInfo = FileVersionInfo.GetVersionInfo( assembly.Location );
            this.Copyright = versionInfo.LegalCopyright;
            this.ProductName = versionInfo.ProductName;

            this.Version = assembly.GetName().Version.ToString();
        }


        public string ProductName { get; private set; }


        public string Version { get; private set; }
    }
#endregion
}
