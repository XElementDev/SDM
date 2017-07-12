namespace XElement.DotNet.System.Environment.Startup.DataTypes
{
#region not unit-tested
    internal class FileOrigin : IFileOrigin
    {
        public FileOrigin() { }


        public bool /*IFileOrigin.*/IsForAllUsers { get; set; }


        public string /*IFileOrigin.*/Location { get; set; }
    }
#endregion
}
