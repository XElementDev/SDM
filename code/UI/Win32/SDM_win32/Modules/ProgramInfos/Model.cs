using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    internal class Model : ViewModelBase
    {
        public Model( IEnumerable<IProgramInfo> programInfos )
        {
            var programInfoModels = programInfos.Select( this.CreateProgramInfoModel ).ToList();
            this.ProgramInfoModels = programInfoModels;
        }


        private ProgramInfo.Model CreateProgramInfoModel( IProgramInfo programInfo )
        {
            return new ProgramInfo.Model( programInfo );
        }


        public void Add( IProgramInfo programInfo )
        {
            var list = (List<ProgramInfo.Model>)this.ProgramInfoModels;
            list.Add( this.CreateProgramInfoModel( programInfo ) );
            this.RaisePropertyChanged( nameof( this.ProgramInfoModels ) );
        }


        public IEnumerable<ProgramInfo.Model> ProgramInfoModels { get; private set; }


        public void Remove( IProgramInfo programInfo )
        {
            var list = (List<ProgramInfo.Model>)this.ProgramInfoModels;
            Func<ProgramInfo.Model, bool> condition = pim => pim.ProgramInfo == programInfo;
            var programInfoModel = this.ProgramInfoModels.Single( condition );
            list.Remove( programInfoModel );
            this.RaisePropertyChanged( nameof( this.ProgramInfoModels ) );
        }
    }
#endregion
}
