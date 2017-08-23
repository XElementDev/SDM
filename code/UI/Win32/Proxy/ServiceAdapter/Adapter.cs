using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using XElement.SDM.UI.Win32.Proxy.Service;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter
{
#region not unit-tested
    internal class Adapter
    {
        public Adapter( string pipeName )
        {
            this._pipeName = pipeName;
        }


        public bool CanStart()
        {
            var isAnotherInstanceAlreadyRunning = false;
            try
            {
                this.CanStart_Workaround();
            }
            catch /*( IOException )*/
            {
                isAnotherInstanceAlreadyRunning = true;
            }
            return !isAnotherInstanceAlreadyRunning;
        }


        //  --> 2016-08-10, Ian:
        //      Workaround because of 'https://github.com/acdvorak/named-pipe-wrapper/issues/7'.
        //TODO:Check if issue is still present.
        private void CanStart_Workaround()
        {
            new NamedPipeServerStream( this._pipeName ).Dispose();
        }


        public void Launch()
        {
            var process = new Process();
            process.StartInfo.FileName = this.PathToLinkCreatorSvcExe;
            process.StartInfo.Arguments = this._pipeName;
            process.StartInfo.CreateNoWindow = true;    // TODO check why a window is created
            process.Start();    // TODO handle if user does not allow admin rights
        }


        private string PathToLinkCreatorSvcExe
        {
            get
            {
                var serviceFileName = new AssemblyInfoAccessor().AssemblyName + ".exe";
                return Path.Combine( Environment.CurrentDirectory, 
                                     serviceFileName );
            }
        }


        private string _pipeName;
    }
#endregion
}
