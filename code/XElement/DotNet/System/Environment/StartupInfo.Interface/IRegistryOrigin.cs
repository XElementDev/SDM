namespace XElement.DotNet.System.Environment.Startup
{
    public interface IRegistryOrigin : IOrigin
    {
        string ValueName { get; }
    }
}
