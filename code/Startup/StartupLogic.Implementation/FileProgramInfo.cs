using System.IO;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.StartupLogic
{
    // TODO
#region not unit-tested
    internal class FileProgramInfo
    {
        public FileProgramInfo( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        public void /*.*/Do()
        {
            var fileName = this._programInfo.Origin.Location;
            var fileInfo = new FileInfo( fileName );
            //fileInfo.Delete();
        }


        public void /**/Undo()
        {
        }


        private IProgramInfo _programInfo;
    }
#endregion
}
