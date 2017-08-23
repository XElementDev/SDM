using NamedPipeWrapper;
using System;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;
using XElement.SDM.UI.Win32.Proxy.Serialization;

namespace XElement.SDM.UI.Win32.Proxy.Logic
{
#region not unit-tested
    public class Server
    {
        public Server( string pipeName )
        {
            this._programLogicFactory = new ProgramLogicFactory();
            this._pipeName = pipeName; InitializeServerPipe();
        }


        private void ClientConnected( NamedPipeConnection<string, string> connection )
        {
            Logger.Get().Log( "A client connected to the server." );
        }


        private void ClientDisconnected( NamedPipeConnection<string, string> connection )
        {
            Logger.Get().Log( "A client disconnected from the server." );
        }


        private void ClientMessage( NamedPipeConnection<string, string> connection, string message )
        {
            var logMessage = $"Received the following message from client: {message}";
            Logger.Get().Log( logMessage ); this.DoWork( message );
            this._serverPipe.PushMessage( string.Empty );
        }


        private static PipeSecurity CreatePipeSecurity()
        {
            //  --> 2016-08-11, Ian:
            //      based on: https://stackoverflow.com/questions/13174660/namedpipeclientstream-can-not-access-to-namedpipeserverstream-under-session-0
            var pipeSecurity = new PipeSecurity();
            var sid = new SecurityIdentifier( WellKnownSidType.WorldSid, null );
            var accessRule = new PipeAccessRule( sid, 
                                                 PipeAccessRights.ReadWrite, 
                                                 AccessControlType.Allow );
            pipeSecurity.AddAccessRule( accessRule );
            return pipeSecurity;
        }


        private void DoWork( string message )
        {
            var proxyParams = new MessageParser().Parse( message );
            if (proxyParams == null)
            {
                var error = String.Format( "Parsed message (of type {0}) must not be null.", 
                                           typeof( IProgramInfo ).ToString() );
                throw new InvalidOperationException( error );
            }
            else
            {
                var proxyParamsAsString = Logger.Get().GetLogRepresentationOf( proxyParams );
                Logger.Get().Log( $"Parsed message looks like this: {proxyParamsAsString}" );

                var command = this._programLogicFactory.Get( proxyParams.ProgramInfo );
                if ( proxyParams.CommandMethod == CommandMethod.Do )
                    command.Do();
                else if ( proxyParams.CommandMethod == CommandMethod.Undo )
                    command.Undo();
            }
        }


        private void InitializeServerPipe()
        {
            PipeSecurity pipeSecurity = CreatePipeSecurity();
            this._serverPipe = new NamedPipeServer<string>( this._pipeName, pipeSecurity );
            this.SubscribeEvents();
        }


        private void OnError( Exception exception )
        {
            throw exception;
        }


        public void Start()
        {
            this._serverPipe.Start();
            Logger.Get().Log( "Server started." );
        }


        public void StayAlive()
        {
            while (true)
            {
            }
        }


        private void SubscribeEvents()
        {
            this._serverPipe.ClientConnected += this.ClientConnected;
            this._serverPipe.ClientDisconnected += this.ClientDisconnected;
            this._serverPipe.ClientMessage += this.ClientMessage;
            this._serverPipe.Error += this.OnError;
        }


        private string _pipeName;
        private IFactory<IProgramLogic, IProgramInfo> _programLogicFactory;
        private NamedPipeServer<string> _serverPipe;
    }
#endregion
}
