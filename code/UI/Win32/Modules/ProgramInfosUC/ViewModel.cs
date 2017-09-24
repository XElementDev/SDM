using GalaSoft.MvvmLight;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using XElement.SDM.UI.Win32.Modules.ProgramInfo;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    [AddINotifyPropertyChangedInterface]
    public class ProgramInfosViewModel : ViewModelBase
    {
        public ProgramInfosViewModel( ProgramInfosModel model )
        {
            this._model = model;
            this.InitializeProgramInfoVMs();

            this._model.PropertyChanged += ( s, e ) => this.UpdateProgramInfoVMs();
        }


        private void InitializeProgramInfoVMs()
        {
            var programInfoVMs = this._model.ProgramInfoModels
                .Select( pim => new ProgramInfoViewModel( pim ) ).ToList();
            this.ProgramInfoVMs = programInfoVMs;
        }


        [DoNotNotify]
        public IEnumerable<ProgramInfoViewModel> ProgramInfoVMs { get; private set; }


        public ProgramInfoViewModel SelectedProgramInfoVM { get; set; }


        private void UpdateProgramInfoVMs()
        {
            this.InitializeProgramInfoVMs();
            this.RaisePropertyChanged( nameof( this.ProgramInfoVMs ) );
        }


        private ProgramInfosModel _model;
    }
#endregion
}
