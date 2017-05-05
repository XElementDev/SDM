using GalaSoft.MvvmLight;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    [ImplementPropertyChanged]
    internal class ViewModel : ViewModelBase
    {
        public ViewModel( Model model )
        {
            this._model = model;
            this.InitializeProgramInfoVMs();

            this._model.PropertyChanged += ( s, e ) => this.UpdateProgramInfoVMs();
        }


        private void InitializeProgramInfoVMs()
        {
            var programInfoVMs = this._model.ProgramInfoModels
                .Select( pim => new ProgramInfo.ViewModel( pim ) ).ToList();
            this.ProgramInfoVMs = programInfoVMs;
        }


        [DoNotNotify]
        public IEnumerable<ProgramInfo.ViewModel> ProgramInfoVMs { get; private set; }


        public ProgramInfo.ViewModel SelectedProgramInfoVM { get; set; }


        private void UpdateProgramInfoVMs()
        {
            this.InitializeProgramInfoVMs();
            this.RaisePropertyChanged( nameof( this.ProgramInfoVMs ) );
        }


        private Model _model;
    }
#endregion
}
