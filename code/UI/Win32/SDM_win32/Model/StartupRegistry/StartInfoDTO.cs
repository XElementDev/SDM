using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Model.StartupRegistry
{
#region not unit-tested
    internal class StartInfoDTO : IStartInfo
    {
        public StartInfoDTO() { }


        public string /*IStartInfo.*/Arguments { get; set; }


        public string /*IStartInfo.*/FilePath { get; set; }
    }
#endregion
}
