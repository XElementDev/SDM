using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;

namespace XElement.SDM.UI.Win32.Proxy.ServiceAdapter.MefExtensions
{
#region not unit-tested
    [Export( typeof( IFactory<IProgramLogic, IProgramInfo> ) )]
    internal class ProgramLogicFactory : 
        global::XElement.SDM.UI.Win32.Proxy.ServiceAdapter.ProgramLogicFactory, 
        IPartImportsSatisfiedNotification
    {
        public ProgramLogicFactory() : base( null ) { }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._nonAdminFactory = this._mefNonAdminFactory;
        }


        [Import( "3B0490BF-1ECE-470E-B0AE-C5085C592C08" )]
        private IFactory<IProgramLogic, IProgramInfo> _mefNonAdminFactory = null;
    }
#endregion
}
