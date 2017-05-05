using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.StartupLogic
{
#region not unit-tested
    // TODO
    internal class RegistryProgramInfo : IProgramLogic
    {
        public RegistryProgramInfo( IProgramInfo programInfo )
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
