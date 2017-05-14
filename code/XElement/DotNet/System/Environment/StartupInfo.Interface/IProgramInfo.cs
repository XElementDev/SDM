namespace XElement.DotNet.System.Environment.Startup
{
    public interface IProgramInfo
    {
        string Arguments { get; }


        string FilePath { get; }


        IOrigin Origin { get; }
    }
}
