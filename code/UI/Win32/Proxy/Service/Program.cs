namespace XElement.SDM.UI.Win32.Proxy.Service
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    class Program
    {
        static void Main( string[] args )
        {
            var parser = new ArgsParser( args );

            var server = new Logic.Server( parser.PipeName );
            server.Start();
            server.StayAlive();
        }
    }
#endregion
}
