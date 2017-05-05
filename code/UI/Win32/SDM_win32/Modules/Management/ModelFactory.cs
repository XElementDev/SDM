using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    [Export( typeof( IFactory<Model, ModelParameters> ) )]
    internal class ModelFactory : IFactory<Model, ModelParameters>
    {
        [ImportingConstructor]
        private ModelFactory()
        {
            this._dependencies = null;
        }


        public Model /*IFactoryT2.*/Get( ModelParameters parameters )
        {
            return new Model( parameters, this._dependencies );
        }


        [Import]
        private ModelDependencies _dependencies;
    }
#endregion
}
