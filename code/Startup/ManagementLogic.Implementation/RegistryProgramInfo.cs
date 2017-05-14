using Microsoft.Win32;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic
{
#region not unit-tested
    internal class RegistryProgramInfo : IProgramLogic
    {
        public RegistryProgramInfo( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }


        public void /*IProgramLogic.*/Do()
        {
            this.SubKey.DeleteValue( this.Origin.ValueName );
        }


        private IRegistryOrigin Origin
        {
            get { return (IRegistryOrigin)this._programInfo.Origin; }
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
            var value = $"\"{this._programInfo.FilePath}\" {this._programInfo.Arguments}";
            this.SubKey.SetValue( this.Origin.ValueName, value );
        }


        private IProgramInfo _programInfo;
    }
#endregion
}
