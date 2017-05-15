namespace XElement.DotNet.System.Environment.Startup
{
    public interface IProgramInfo
    {
        IOrigin Origin { get; }


        IStartInfo StartInfo { get; }
    }
}
