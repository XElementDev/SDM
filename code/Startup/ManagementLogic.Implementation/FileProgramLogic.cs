using IWshRuntimeLibrary;
using System.IO;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic
{
#region not unit-tested
    internal class FileProgramLogic : AbstractProgramLogic, IProgramLogic
    {
        public FileProgramLogic( IProgramInfo programInfo ) : base( programInfo ) { }


        public override void /*AbstractProgramLogic.*/DelayStartup()
        {
            var fileName = this._programInfo.Origin.Location;
            var fileInfo = new FileInfo( fileName );
            fileInfo.Delete();
        }


        //  --> https://stackoverflow.com/questions/18023379/creating-a-file-shortcut-lnk
        public override void /*AbstractProgramLogic.*/PromoteStartup()
        {
            var fileName = this._programInfo.Origin.Location;
            var wsh = new IWshShell_Class();
            var shortcut = wsh.CreateShortcut( fileName ) as IWshShortcut;
            shortcut.TargetPath = this._programInfo.StartInfo.FilePath;
            shortcut.Arguments = this._programInfo.StartInfo.Arguments;
            shortcut.Save();
        }
    }
#endregion
}
