using System.ComponentModel.Composition;
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
        #endregion
    }
#endregion
}
