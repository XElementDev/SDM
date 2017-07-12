using XElement.DotNet.System.Environment.Startup.Technical;
using SysEnv = global::System.Environment;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class GlobalFileSystemRetriever : FileSystemRetrieverBase, IStartupInfo
    {
        protected override bool /*FileSystemRetrieverBase.*/IsForAllUsers { get { return true; } }


        protected override string /*FileSystemRetrieverBase.*/RoamingFolderPath
        {
            get { return SysEnv.GetFolderPath( SysEnv.SpecialFolder.CommonApplicationData ); }
        }
    }
#endregion
}
