using Prism.Events;
using System.ComponentModel.Composition;

namespace XElement.SDM.UI.Win32.Model.AutoSave
{
#region not unit-tested
    [Export]
    internal class AutoSaveModelDependencies
    {
        [ImportingConstructor]
        public AutoSaveModelDependencies() { }


        [Import]
        public IEventAggregator EventAggregator { get; set; }
    }
#endregion
}
