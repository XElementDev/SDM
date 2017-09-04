using System;
using System.ComponentModel.Composition;
using System.IO;
using XElement.SDM.UI.Win32.Model.AutoSave;
using XElement.SDM.UI.Win32.Serialization;

namespace XElement.SDM.UI.Win32.Model.Serialization
{
#region not unit-tested
    //TODO: DRY w.r.t. LocalDataContainer
    [Export]
    [Export( typeof( IAutoSaveTarget ) )]
    internal class GlobalDataContainer : IAutoSaveTarget
    {
        [ImportingConstructor]
        public GlobalDataContainer()
        {
            this.InitializeFilePath();
            this.TryCreateFilePath();
            this._serializationManager = new SerializationManager( this._filePath );
            this.InitializeData();
        }


        public IData Data { get; set; }


        private void InitializeData()
        {
            this.Data = this._serializationManager.Deserialize();
        }


        private void InitializeFilePath()
        {
            var specialFolder = Environment.SpecialFolder.CommonApplicationData;
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
