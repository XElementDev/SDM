using System.Reflection;

namespace XElement.SDM.UI.Win32.Proxy.Service
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    public class AssemblyInfoAccessor
    {
        public AssemblyInfoAccessor()
        {
            this.AssemblyName = this.GetAssemblyName();
        }


        public string AssemblyName { get; private set; }


        private string GetAssemblyName()
        {
            return Assembly.GetAssembly( this.GetType() ).GetName().Name;
        }
    }
#endregion
}
