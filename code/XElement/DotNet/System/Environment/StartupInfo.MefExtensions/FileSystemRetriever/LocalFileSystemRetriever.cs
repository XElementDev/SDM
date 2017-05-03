using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.Startup.MefExtensions
{
#region not unit-tested
    [Export( typeof( IStartupInfoInt ) )]
    internal class LocalFileSystemRetriever : 
        global::XElement.DotNet.System.Environment.Startup.LocalFileSystemRetriever { }
#endregion
}
