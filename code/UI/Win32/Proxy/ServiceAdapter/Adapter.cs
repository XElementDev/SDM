using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using XElement.SDM.UI.Win32.Proxy.Service;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
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


        //  --> 2017-09-03, Ian:
        //      Workaround because of 'https://github.com/acdvorak/named-pipe-wrapper/issues/7'.
        private void CanStart_Workaround()
        {
            new NamedPipeServerStream( this._pipeName ).Dispose();
        }


        private ProcessStartInfo CreateStartInfo()
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = this._pipeName,
                CreateNoWindow = true,
                FileName = this.PathToLinkCreatorSvcExe,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            return startInfo;
        }


        public void Launch()
        {
            var process = new Process { StartInfo = this.CreateStartInfo() };
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
