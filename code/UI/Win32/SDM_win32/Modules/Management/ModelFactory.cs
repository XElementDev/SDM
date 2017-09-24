using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    [Export( typeof( IFactory<ManagementModel, ManagementModelParameters> ) )]
    internal class ManagementModelFactory : IFactory<ManagementModel, ManagementModelParameters>
    {
        [ImportingConstructor]
        private ManagementModelFactory()
        {
            this._dependencies = null;
        }


        public ManagementModel /*IFactoryT2.*/Get( ManagementModelParameters parameters )
        {
            return new ManagementModel( parameters, this._dependencies );
        }


        [Import]
        private MainModelDependencies _dependencies;
    }
#endregion
}
