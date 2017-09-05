using Microsoft.Win32;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic
{
#region not unit-tested
    internal class RegistryProgramLogic : IProgramLogic
    {
        public RegistryProgramLogic( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        public void /*IProgramLogic.*/DelayStartup()
        {
            this.Do();
        }


        public void /*IProgramLogic.*/Do()
        {
            this.SubKey.DeleteValue( this.Origin.ValueName );
        }


        private IRegistryOrigin Origin
        {
            get { return (IRegistryOrigin)this._programInfo.Origin; }
        }


        public void /*IProgramLogic.*/PromoteStartup()
        {
            this.Undo();
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


        public void /*IProgramLogic.*/Undo()
        {
            var startInfo = this._programInfo.StartInfo;
            var value = $"\"{startInfo.FilePath}\" {startInfo.Arguments}";
            this.SubKey.SetValue( this.Origin.ValueName, value );
        }


        private IProgramInfo _programInfo;
    }
#endregion
}
