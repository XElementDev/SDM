using System.ComponentModel.Composition;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class ViewModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public ViewModel( Model model )
        {
            this._model = model;
        }


        public Management.ViewModel ManagementVM { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.ManagementVM = new Management.ViewModel( this._model.ManagementModel );
        }


        private Model _model;
    }
#endregion
}
