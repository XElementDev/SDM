using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.Startup.MefExtensions
{
#region not unit-tested
    [Export( typeof( IStartupInfoInt ) )]
    internal class RegistryRetriever64bit : 
        global::XElement.DotNet.System.Environment.Startup.RegistryRetriever64bit { }
#endregion
}
