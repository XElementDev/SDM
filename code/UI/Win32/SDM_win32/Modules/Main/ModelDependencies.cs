using System.ComponentModel.Composition;
using XElement.SDM.UI.Win32.Model;
using AutoSave = global::XElement.SDM.UI.Win32.Model.AutoSave;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class ModelDependencies
    {
        [ImportingConstructor]
        public ModelDependencies() { }


        #region import-only
        [Import]
        public AutoSave.Model AutoSaveModel { get; set; }


        [Import]
        public DelayModel DelayModel { get; set; }
        #endregion
    }
#endregion
}
