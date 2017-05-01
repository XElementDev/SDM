using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
#region not unit-tested
    internal class Model
    {
        public Model( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        // TODO


        private IProgramInfo _programInfo;
    }
#endregion
}
