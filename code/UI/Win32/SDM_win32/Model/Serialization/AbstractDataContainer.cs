using System;
using System.IO;
using XElement.SDM.UI.Win32.Model.AutoSave;
using XElement.SDM.UI.Win32.Serialization;

namespace XElement.SDM.UI.Win32.Model.Serialization
{
#region not unit-tested
    internal abstract class AbstractDataContainer : IAutoSaveTarget
    {
        public AbstractDataContainer()
        {
            this.InitializeFilePath();
            this.TryCreateFilePath();
            this._serializationManager = new SerializationManager( this._filePath );
            this.InitializeData();
        }


        public IData Data { get; set; }


        protected abstract Environment.SpecialFolder GetSpecialFolder();


        private void InitializeData()
        {
            this.Data = this._serializationManager.Deserialize();
        }


        private void InitializeFilePath()
        {
            var specialFolder = this.GetSpecialFolder();
            var rootFolderPath = Environment.GetFolderPath( specialFolder );
            var subFolderPath = Path.Combine( SUB_FOLDERS );
            var filePath = Path.Combine( rootFolderPath, subFolderPath, FILE_NAME );
            this._filePath = filePath;
        }


        void IAutoSaveTarget.Persist()
        {
            this._serializationManager.Serialize( this.Data );
        }


        private void TryCreateFilePath()
        {
            var fileInfo = new FileInfo( this._filePath );
            var folderPath = fileInfo.DirectoryName;
            if ( !Directory.Exists( folderPath ) )
            {
                Directory.CreateDirectory( folderPath );
            }
        }


        private const string FILE_NAME = "data.xml";

        private readonly string[] SUB_FOLDERS = new string[2] { "XElement", "SDM" };


        private string _filePath;

        private ISerializationManager _serializationManager;
    }
#endregion
}
