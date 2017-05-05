using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class Model
    {
        public Model( ModelParameters parameters )
        {
            this.DelayedProgramInfosModel = new ProgramInfos.Model( parameters.DelayedProgramInfos );
            this.StartupProgramInfosModel = new ProgramInfos.Model( parameters.StartupProgramInfos );
        }


        public ProgramInfos.Model DelayedProgramInfosModel { get; private set; }


        public ProgramInfos.Model StartupProgramInfosModel { get; private set; }
    }
#endregion
}
