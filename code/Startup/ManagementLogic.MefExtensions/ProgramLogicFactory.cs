using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic.MefExtensions
{
#region not unit-tested
    [Export( "3B0490BF-1ECE-470E-B0AE-C5085C592C08", 
             typeof( IFactory<IProgramLogic, IProgramInfo> ) )]
    internal class ProgramLogicFactory : global::XElement.SDM.ManagementLogic.ProgramLogicFactory { }
#endregion
}
