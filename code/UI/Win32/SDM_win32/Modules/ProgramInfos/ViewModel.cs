using System.Collections.Generic;
using System.Linq;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this._model = model;

            var programInfoVMs = this._model.ProgramInfoModels
                .Select( pim => new ProgramInfo.ViewModel( pim ) ).ToList();
            this.ProgramInfoVMs = programInfoVMs;
        }


        public IEnumerable<ProgramInfo.ViewModel> ProgramInfoVMs { get; private set; }


        private Model _model;
    }
#endregion
}
