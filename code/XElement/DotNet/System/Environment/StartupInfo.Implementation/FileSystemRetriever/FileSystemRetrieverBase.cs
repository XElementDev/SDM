using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XElement.DotNet.System.Environment.Startup.DataTypes;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public abstract class FileSystemRetrieverBase : IStartupInfo
    {
        public FileSystemRetrieverBase() { }


        private IOrigin CreateOriginFrom( string filePath )
        {
            var origin = new FileOrigin
            {
                IsForAllUsers = this.IsForAllUsers, 
                Location = filePath
            };
            return origin;
        }


        private IProgramInfo CreateProgramInfoFromFilePath( string filePath )
        {
            var programInfo = new ProgramInfo
            {
                Origin = this.CreateOriginFrom( filePath ), 
                StartInfo = FileSystemRetrieverBase.CreateStartInfoFrom( filePath )
            };
            return programInfo;
        }


        private static IStartInfo CreateStartInfoFrom( string filePath )
        {
            var shortcut = FileSystemRetrieverBase.GetShortcutInfo( filePath );
            var startInfo = new StartInfo
            {
                Arguments = shortcut.Arguments, 
                FilePath = shortcut.TargetPath
            };
            return startInfo;
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


        protected abstract bool IsForAllUsers { get; }


        private static bool IsHiddenFile( FileInfo fileInfo )
        {
            var isHidden = fileInfo.Attributes.HasFlag( FileAttributes.Hidden );
            return !isHidden;
        }


        public IEnumerable<IProgramInfo> Retrieve()
        {
            var filePaths = this.GetFilePathsOfFilesInStartupFolder();
            var programInfos = filePaths.Select( this.CreateProgramInfoFromFilePath ).ToList();
            return programInfos;
        }


        protected abstract string RoamingFolderPath { get; }
    }
#endregion
}
