using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Proxy.Serialization;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter
{
#region not unit-tested
    internal class ProxyParametersDTO : IProxyParameters
    {
        public ProxyParametersDTO() { }


        public CommandMethod /*IProxyParameters.*/CommandMethod { get; set; }


        public IProgramInfo /*IProxyParameters.*/ProgramInfo { get; set; }
    }
#endregion
}
