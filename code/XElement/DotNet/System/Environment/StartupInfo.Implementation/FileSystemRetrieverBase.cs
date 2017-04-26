﻿using System.Collections.Generic;
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
            var origin = new FileOrigin { Location = filePath };
            var programInfo = new ProgramInfo
            {
                Argument = "TODO",
                FilePath = "TODO",
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
