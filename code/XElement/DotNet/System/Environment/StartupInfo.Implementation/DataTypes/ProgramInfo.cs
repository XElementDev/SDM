namespace XElement.DotNet.System.Environment.Startup.DataTypes
{
#region not unit-tested
    internal class ProgramInfo : IProgramInfo
    {
        public string /*IProgramInfo.*/Arguments { get; set; }


        public string /*IProgramInfo.*/FilePath { get; set; }


        public IOrigin /*IProgramInfo.*/Origin { get; set; }
    }
#endregion
}
