using Microsoft.Practices.Prism.Events;
using System.ComponentModel.Composition;

namespace XElement.SDM.UI.Win32.Model.AutoSave
{
#region not unit-tested
    [Export]
    internal class ModelDependencies
    {
        [ImportingConstructor]
        public ModelDependencies() { }


        [Import]
        public IEventAggregator EventAggregator { get; set; }
    }
#endregion
}
