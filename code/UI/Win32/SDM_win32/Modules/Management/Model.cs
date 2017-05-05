using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    internal class Model
    {
        public Model( ModelParameters parameters )
        {
            var delayed = new ProgramInfos.Model( parameters.DelayedProgramInfos );
            this.DelayedProgramInfosModel = delayed;

            var startup = new ProgramInfos.Model( parameters.StartupProgramInfos );
            this.StartupProgramInfosModel = startup;
        }


        public ProgramInfos.Model DelayedProgramInfosModel { get; private set; }


        public ProgramInfos.Model StartupProgramInfosModel { get; private set; }
    }
#endregion
}
