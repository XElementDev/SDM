using XElement.DotNet.System.Environment.Startup.Technical;
using SysEnv = global::System.Environment;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class LocalFileSystemRetriever : FileSystemRetrieverBase, IStartupInfo
    {
        protected override bool /*FileSystemRetrieverBase.*/IsForAllUsers { get { return false; } }


        protected override string RoamingFolderPath
        {
            get { return SysEnv.GetFolderPath( SysEnv.SpecialFolder.ApplicationData ); }
        }
    }
#endregion
}
