using System;
using System.ComponentModel.Composition;
using System.IO;
using XElement.SDM.UI.Win32.Model.AutoSave;
using XElement.SDM.UI.Win32.Serialization;

namespace XElement.SDM.UI.Win32.Model.Serialization
{
#region not unit-tested
    [Export]
    [Export( typeof( IAutoSaveTarget ) )]
    internal class LocalDataContainer : IAutoSaveTarget
    {
        [ImportingConstructor]
        public LocalDataContainer()
        {
            this.TryCreateFilePath();
            this._serializationManager = new SerializationManager( this.FilePath );
        }


        private IData _data;

        public IData Data
        {
            get { return this._serializationManager.Deserialize(); }
            set { this._data = value; }
        }


        private string FilePath
        {
            get
            {
                var specialFolder = Environment.SpecialFolder.LocalApplicationData;
                var rootFolderPath = Environment.GetFolderPath( specialFolder );
                var subFolderPath = Path.Combine( SUB_FOLDERS );
                return Path.Combine( rootFolderPath, subFolderPath, FILE_NAME );
            }
        }


        void IAutoSaveTarget.Persist()
        {
            this._serializationManager.Serialize( this._data );
        }


        private void TryCreateFilePath()
        {
            var fileInfo = new FileInfo( this.FilePath );
            var folderPath = fileInfo.DirectoryName;
            if ( !Directory.Exists( folderPath ) )
            {
                Directory.CreateDirectory( folderPath );
            }
        }


        private const string FILE_NAME = "data.xml";

        private readonly string[] SUB_FOLDERS = new string[2] { "XElement", "SDM" };


        private ISerializationManager _serializationManager;
    }
#endregion
}
