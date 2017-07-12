namespace XElement.DotNet.System.Environment.Startup
{
    public interface IOrigin
    {
        bool IsForAllUsers { get; }


        string Location { get; }
    }
}
