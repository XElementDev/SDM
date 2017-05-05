using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.StartupLogic
{
#region not unit-tested
    public class ProgramLogicFactory : IFactory<IProgramLogic, IProgramInfo>
    {
        public ProgramLogicFactory() { }


        public IProgramLogic /*IFactoryT2.*/Get( IProgramInfo programInfo )
        {
            IProgramLogic instance = null;

            if ( programInfo.Origin is IFileOrigin )
            {
                instance = new FileProgramInfo( programInfo );
            }
            else if ( programInfo.Origin is IRegistryOrigin )
            {
                instance = new RegistryProgramInfo( programInfo );
            }

            return instance;
        }
    }
#endregion
}
