using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public abstract class FileSystemRetrieverBase : IStartupInfo
    {
        public FileSystemRetrieverBase() { }


        private IProgramInfo CreateProgramInfoFromFilePath( string filePath )
        {
            var shortcut = this.GetShortcutInfo( filePath );
            var origin = new FileOrigin { Location = filePath };
            var programInfo = new ProgramInfo
            {
                Argument = shortcut.Arguments,
                FilePath = shortcut.TargetPath,
                Origin = origin
            };
            return programInfo;
        }


        private IEnumerable<string> GetFilePathsOfFilesInStartupFolder()
        {
            var path = Path.Combine( this.RoamingFolderPath, "Microsoft", "Windows", 
                                     "Start Menu", "Programs", "Startup" );
            var directory = new DirectoryInfo( path );
            var fileInfos = directory.GetFiles();
            var fileInfosOfVisibleFiles = fileInfos.Where( fi => this.IsHiddenFile( fi ) ).ToList();
            var filePaths = fileInfosOfVisibleFiles.Select( fi => fi.FullName ).ToList();
            return filePaths;
        }


        //  --> https://stackoverflow.com/questions/139010/how-to-resolve-a-lnk-in-c-sharp
        private IWshShortcut GetShortcutInfo( string filePath )
        {
            IWshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut( filePath );
            return shortcut;
        }


        private bool IsHiddenFile( FileInfo fileInfo )
        {
            var isHidden = fileInfo.Attributes.HasFlag( FileAttributes.Hidden );
            return !isHidden;
        }


        public IEnumerable<IProgramInfo> Retrieve()
        {
            var filePaths = this.GetFilePathsOfFilesInStartupFolder();
            var programInfos = filePaths.Select( fp => this.CreateProgramInfoFromFilePath( fp ) ).ToList();
            return programInfos;
        }


        protected abstract string RoamingFolderPath { get; }
    }
#endregion
}
