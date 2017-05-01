using System.ComponentModel.Composition;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Model model )
        {
            this.Model = model;
        }


        public Model Model { get; private set; }
    }
#endregion
}
