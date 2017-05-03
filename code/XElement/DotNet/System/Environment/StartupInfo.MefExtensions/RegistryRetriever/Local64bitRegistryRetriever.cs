using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.Startup.MefExtensions
{
#region not unit-tested
    [Export( typeof( IStartupInfoInt ) )]
    internal class Local64bitRegistryRetriever : 
        global::XElement.DotNet.System.Environment.Startup.Local64bitRegistryRetriever { }
#endregion
}
