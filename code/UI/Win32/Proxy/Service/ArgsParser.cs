using System.Linq;

namespace XElement.SDM.UI.Win32.Proxy.Service
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    internal class ArgsParser
    {
        public ArgsParser( string[] args )
        {
            this.Parse( args );
        }


        private void Parse( string[] args )
        {
            if ( args.Length >= 1 )
            {
                this.PipeName = args.First();
            }
        }


        public string PipeName { get; private set; }
    }
#endregion
}
