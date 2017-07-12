using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XElement.DotNet.System.Environment.Startup.DataTypes;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public abstract class FileSystemRetrieverBase : RetrieverBase<string>, IStartupInfo
    {
        public FileSystemRetrieverBase() { }


        protected override IOrigin /*RetrieverBase<T1>.*/CreateOriginFrom( string filePath )
        {
            var origin = new FileOrigin
            {
                IsForAllUsers = this.IsForAllUsers, 
                Location = filePath
            };
            return origin;
        }


        protected override IStartInfo /*RetrieverBase<T1>.*/CreateStartInfoFrom( string filePath )
        {
            return FileSystemRetrieverBase.CreateStartInfoFromString( filePath );
        }

        private static IStartInfo CreateStartInfoFromString( string filePath )
        {
            var shortcut = FileSystemRetrieverBase.GetShortcutInfo( filePath );
            var startInfo = new StartInfo
            {
                Arguments = shortcut.Arguments, 
                FilePath = shortcut.TargetPath
            };
            return startInfo;
        }


        protected override IEnumerable<string> /*RetrieverBase<T1>.*/GetEntitiesForStartInfoCreation()
        {
            return this.GetFilePathsOfFilesInStartupFolder();
        }


        private IEnumerable<string> GetFilePathsOfFilesInStartupFolder()
        {
            var path = Path.Combine( this.RoamingFolderPath, "Microsoft", "Windows", 
                                     "Start Menu", "Programs", "Startup" );
            var directory = new DirectoryInfo( path );
            var fileInfos = directory.GetFiles();
            var fileInfosOfVisibleFiles = fileInfos.Where( IsHiddenFile ).ToList();
            var filePaths = fileInfosOfVisibleFiles.Select( fi => fi.FullName ).ToList();
            return filePaths;
        }


        //  --> https://stackoverflow.com/questions/139010/how-to-resolve-a-lnk-in-c-sharp
        private static IWshShortcut GetShortcutInfo( string filePath )
        {
            IWshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut( filePath );
            return shortcut;
        }


        private static bool IsHiddenFile( FileInfo fileInfo )
        {
            var isHidden = fileInfo.Attributes.HasFlag( FileAttributes.Hidden );
            return !isHidden;
        }


        protected abstract string RoamingFolderPath { get; }
    }
#endregion
}
