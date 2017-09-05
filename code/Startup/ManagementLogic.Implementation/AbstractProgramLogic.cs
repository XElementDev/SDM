using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic
{
#region not unit-tested
    internal abstract class AbstractProgramLogic : IProgramLogic
    {
        protected AbstractProgramLogic( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        public abstract void /*IProgramLogic.*/DelayStartup();


        public void /*IProgramLogic.*/Do() { this.DelayStartup(); }


        public abstract void /*IProgramLogic.*/PromoteStartup();


        public void /*IProgramLogic.*/Undo() { this.PromoteStartup(); }


        protected IProgramInfo _programInfo;
    }
#endregion
}
