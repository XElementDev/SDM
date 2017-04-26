namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class ProgramInfo : IProgramInfo
    {
        public string /*IProgramInfo.*/Argument { get; set; }


        public string /*IProgramInfo.*/FilePath { get; set; }


        public IOrigin /*IProgramInfo.*/Origin { get; set; }
    }
#endregion
}
