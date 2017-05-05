using System.Collections.Generic;
using System.Linq;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfos
{
#region not unit-tested
    internal class Model
    {
        public Model( IEnumerable<IProgramInfo> programInfos )
        {
            var programInfoModels = programInfos.Select( pi => new ProgramInfo.Model( pi ) )
                .ToList();
            this.ProgramInfoModels = programInfoModels;
        }


        public IEnumerable<ProgramInfo.Model> ProgramInfoModels { get; private set; }
    }
#endregion
}
