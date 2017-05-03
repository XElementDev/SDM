using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.Startup.MefExtensions
{
#region not unit-tested
    [Export( typeof( IStartupInfoInt ) )]
    internal class GlobalFileSystemRetriever : 
        global::XElement.DotNet.System.Environment.Startup.GlobalFileSystemRetriever { }
#endregion
}
