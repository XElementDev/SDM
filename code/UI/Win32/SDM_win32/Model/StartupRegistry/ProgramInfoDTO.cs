using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Model.StartupRegistry
{
#region not unit-tested
    internal class ProgramInfoDTO : IProgramInfo
    {
        public ProgramInfoDTO() { }


        public IOrigin /*IProgramInfo.*/Origin { get; set; }


        public IStartInfo /*IProgramInfo.*/StartInfo { get; set; }
    }
#endregion
}
