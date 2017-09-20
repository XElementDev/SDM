using System.ComponentModel.Composition;

namespace XElement.SDM.UI.Win32.Modules.About
{
#region not unit-tested
    [Export]
    internal class ViewModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private ViewModel() { }


        [Import]
        public Model Model { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.Version = $"v{ this.Model.Version }";
        }


        public string Version { get; private set; }
    }
#endregion
}
