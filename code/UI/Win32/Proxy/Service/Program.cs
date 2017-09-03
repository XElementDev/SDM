using XElement.SDM.UI.Win32.Proxy.Logic;

namespace XElement.SDM.UI.Win32.Proxy.Service
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    class Program
    {
        static void Main( string[] args )
        {
            var pipeName = new ArgsParser( args ).PipeName;
            InitializeServer( pipeName );
        }



        private static void InitializeServer( string pipeName )
        {
            _server = new Server( pipeName );
            _server.Start();
            _server.StayAlive();
        }


        private static Server _server;
    }
#endregion
}
