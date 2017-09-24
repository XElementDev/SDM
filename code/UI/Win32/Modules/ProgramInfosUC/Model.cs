using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Modules.ProgramInfo;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    public class ProgramInfosModel : ViewModelBase
    {
        public ProgramInfosModel( IEnumerable<IProgramInfo> programInfos )
        {
            var programInfoModels = programInfos.Select( this.CreateProgramInfoModel ).ToList();
            this.ProgramInfoModels = programInfoModels;
        }


        private ProgramInfoModel CreateProgramInfoModel( IProgramInfo programInfo )
        {
            return new ProgramInfoModel( programInfo );
        }


        public void Add( IProgramInfo programInfo )
        {
            var list = (List<ProgramInfoModel>)this.ProgramInfoModels;
            list.Add( this.CreateProgramInfoModel( programInfo ) );
            this.RaisePropertyChanged( nameof( this.ProgramInfoModels ) );
        }


        public IEnumerable<ProgramInfoModel> ProgramInfoModels { get; private set; }


        public void Remove( IProgramInfo programInfo )
        {
            var list = (List<ProgramInfoModel>)this.ProgramInfoModels;
            Func<ProgramInfoModel, bool> condition = pim => pim.ProgramInfo == programInfo;
            var programInfoModel = this.ProgramInfoModels.Single( condition );
            list.Remove( programInfoModel );
            this.RaisePropertyChanged( nameof( this.ProgramInfoModels ) );
        }
    }
#endregion
}
