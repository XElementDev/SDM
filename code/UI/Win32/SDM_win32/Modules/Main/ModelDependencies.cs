using System.ComponentModel.Composition;
using XElement.SDM.UI.Win32.Model;
using XElement.SDM.UI.Win32.Model.AutoSave;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class MainModelDependencies
    {
        [ImportingConstructor]
        public MainModelDependencies() { }


        #region import-only
        [Import]
        public AutoSaveModel AutoSaveModel { get; set; }


        [Import]
        public DelayModel DelayModel { get; set; }


        [Import]
        public StartupRegistration StartupRegistration { get; set; }
        #endregion
    }
#endregion
}
