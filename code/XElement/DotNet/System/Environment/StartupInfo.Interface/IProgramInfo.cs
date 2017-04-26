namespace XElement.DotNet.System.Environment.Startup
{
    public interface IProgramInfo
    {
        string Argument { get; }


        string FilePath { get; }


        IOrigin Origin { get; }
    }
}
