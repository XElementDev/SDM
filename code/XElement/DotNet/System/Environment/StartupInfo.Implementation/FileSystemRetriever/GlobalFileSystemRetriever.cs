using SysEnv = global::System.Environment;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class GlobalFileSystemRetriever : FileSystemRetrieverBase, IStartupInfo
    {
        protected override string RoamingFolderPath
        {
            get { return SysEnv.GetFolderPath( SysEnv.SpecialFolder.CommonApplicationData ); }
        }
    }
#endregion
}
