using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Model.StartupRegistry
{
#region not unit-tested
    internal class FileOriginDTO : IFileOrigin
    {
        public FileOriginDTO() { }


        public bool /*IFileOrigin.*/IsForAllUsers { get; set; }


        public string /*IFileOrigin.*/Location { get; set; }
    }
#endregion
}
