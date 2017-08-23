using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter
{
#region not unit-tested
    public class ProgramLogicFactory : IFactory<IProgramLogic, IProgramInfo>
    {
        public IProgramLogic /*IFactoryT2.*/Get( IProgramInfo programInfo )
        {
            return new ProxyProgramLogic( programInfo );
        }
    }
#endregion
}
