using Microsoft.Win32;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic
{
#region not unit-tested
    internal class RegistryProgramLogic : AbstractProgramLogic, IProgramLogic
    {
        public RegistryProgramLogic( IProgramInfo programInfo ) : base( programInfo ) { }


        public override void /*AbstractProgramLogic.*/DelayStartup()
        {
            this.SubKey.DeleteValue( this.Origin.ValueName );
        }


        private IRegistryOrigin Origin
        {
            get { return (IRegistryOrigin)this._programInfo.Origin; }
        }


        public override void /*AbstractProgramLogic.*/PromoteStartup()
        {
            var startInfo = this._programInfo.StartInfo;
            string value = $"\"{startInfo.FilePath}\" {startInfo.Arguments}";
            this.SubKey.SetValue( this.Origin.ValueName, value );
        }


        private RegistryKey SubKey
        {
            get
            {
                var baseKey = RegistryKey.OpenBaseKey( this.Origin.TopLevelNode, this.Origin.Mode );
                var subKey = baseKey.OpenSubKey( this.Origin.SubKey, writable: true );
                return subKey;
            }
        }
    }
#endregion
}
