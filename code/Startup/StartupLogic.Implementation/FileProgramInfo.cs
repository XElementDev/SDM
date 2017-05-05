using System.IO;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.StartupLogic
{
#region not unit-tested
    // TODO
    internal class FileProgramInfo : IProgramLogic
    {
        public FileProgramInfo( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        public void /*IProgramLogic.*/Do()
        {
        }


        public void /*IProgramLogic.*/Undo()
        {
        }


        private IProgramInfo _programInfo;
    }
#endregion
}
