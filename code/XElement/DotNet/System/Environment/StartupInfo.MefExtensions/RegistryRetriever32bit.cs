using System.ComponentModel.Composition;

namespace XElement.DotNet.System.Environment.Startup.MefExtensions
{
#region not unit-tested
    [Export( typeof( IStartupInfoInt ) )]
    internal class RegistryRetriever32bit : 
        global::XElement.DotNet.System.Environment.Startup.RegistryRetriever32bit { }
#endregion
}
