using System.ComponentModel.Composition;
using XElement.SDM.UI.Win32.Modules.Management;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class MainViewModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public MainViewModel( MainModel model )
        {
            this._model = model;
        }


        public ManagementViewModel ManagementVM { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.ManagementVM = new ManagementViewModel( this._model.ManagementModel );
        }


        private MainModel _model;
    }
#endregion
}
