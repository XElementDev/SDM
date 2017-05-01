using System.ComponentModel.Composition;

namespace XElement.SDM.UI.Win32.Modules.Main
{
#region not unit-tested
    [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Model model )
        {
            this._model = model;
        }


        [Import]
        public ProgramInfos.ViewModel ProgramInfosVM { get; private set; }


        private Model _model;
    }
#endregion
}
