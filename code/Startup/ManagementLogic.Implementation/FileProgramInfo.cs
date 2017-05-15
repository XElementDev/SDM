using IWshRuntimeLibrary;
using System.IO;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic
{
#region not unit-tested
    internal class FileProgramInfo : IProgramLogic
    {
        public FileProgramInfo( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        public void /*IProgramLogic.*/Do()
        {
            var fileName = this._programInfo.Origin.Location;
            var fileInfo = new FileInfo( fileName );
            fileInfo.Delete();
        }


        //  --> https://stackoverflow.com/questions/18023379/creating-a-file-shortcut-lnk
        public void /*IProgramLogic.*/Undo()
        {
            var fileName = this._programInfo.Origin.Location;
            var wsh = new IWshShell_Class();
            var shortcut = wsh.CreateShortcut( fileName ) as IWshShortcut;
            shortcut.TargetPath = this._programInfo.StartInfo.FilePath;
            shortcut.Arguments = this._programInfo.StartInfo.Arguments;
            shortcut.Save();
        }


        private IProgramInfo _programInfo;
    }
#endregion
}
