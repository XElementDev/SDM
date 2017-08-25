using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter
{
#region not unit-tested
    public class ProgramLogicFactory : IFactory<IProgramLogic, IProgramInfo>
    {
        public ProgramLogicFactory( IFactory<IProgramLogic, IProgramInfo> nonAdminFactory )
        {
            this._nonAdminFactory = nonAdminFactory;
        }


        public IProgramLogic /*IFactoryT2.*/Get( IProgramInfo programInfo )
        {
            IProgramLogic programLogic = null;

            if ( programInfo.Origin.IsForAllUsers )
            {
                programLogic = new ProxyProgramLogic( programInfo );
            }
            else
            {
                programLogic = this._nonAdminFactory.Get( programInfo );
            }

            return programLogic;
        }


        protected IFactory<IProgramLogic, IProgramInfo> _nonAdminFactory;
    }
#endregion
}
