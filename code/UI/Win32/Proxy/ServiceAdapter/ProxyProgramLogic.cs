using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;
using XElement.SDM.UI.Win32.Proxy.Logic;
using XElement.SDM.UI.Win32.Proxy.Serialization;
using IProxySerializationManager = XElement.SDM.UI.Win32.Proxy.Serialization.IManager;
using ProxySerializationManager = XElement.SDM.UI.Win32.Proxy.Serialization.Manager;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    internal class ProxyProgramLogic : IProgramLogic
    {
        public ProxyProgramLogic( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
            this._serializationManager = new ProxySerializationManager();
        }


        private Client CreateClient()
        {
            Client client = new Client( ClientServer.PIPE_NAME_ALL_USERS );
            return client;
        }


        private string CreateMessage( CommandMethod commandMethod )
        {
            var dto = new ProxyParametersDTO
            {
                CommandMethod = commandMethod, 
                ProgramInfo = this._programInfo
            };
            string message = this._serializationManager.Serialize( dto );
            return message;
        }


        public void /*IProgramLogic.*/Do()
        {
            this.Execute( CommandMethod.Do );
        }


        private void Execute( CommandMethod cmdMethod )
        {
            this.TryLaunchServer();
            var client = this.CreateClient();
            client.PlayBack( this.CreateMessage( cmdMethod ) );
        }


        private void TryLaunchServer()
        {
            var server = new Adapter( ClientServer.PIPE_NAME_ALL_USERS );
            if( server.CanStart() )
            {
                server.Launch();
            }
        }


        public void /*IProgramLogic.*/Undo()
        {
            this.Execute( CommandMethod.Undo );
        }


        private IProgramInfo _programInfo;
        private IProxySerializationManager _serializationManager;
    }
#endregion
}
