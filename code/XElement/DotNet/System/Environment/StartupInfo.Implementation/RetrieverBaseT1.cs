using System.Collections.Generic;
using System.Linq;
using XElement.DotNet.System.Environment.Startup.DataTypes;

namespace XElement.DotNet.System.Environment.Startup.Technical
{
#region not unit-tested
    public abstract class RetrieverBase<T> : IStartupInfo
    {
        public RetrieverBase() { }


        protected abstract IOrigin CreateOriginFrom( T entity );


        private IProgramInfo CreateProgramInfoFrom( T entity )
        {
            var programInfo = new ProgramInfo
            {
                Origin = this.CreateOriginFrom( entity ),
                StartInfo = this.CreateStartInfoFrom( entity )
            };
            return programInfo;
        }


        protected abstract IStartInfo CreateStartInfoFrom( T entity );


        protected abstract IEnumerable<T> GetEntitiesForStartInfoCreation();


        protected abstract bool IsForAllUsers { get; }


        public IEnumerable<IProgramInfo> /*IStartupInfo.*/Retrieve()
        {
            var entities = this.GetEntitiesForStartInfoCreation();
            var programInfos = entities.Select( this.CreateProgramInfoFrom ).ToList();
            return programInfos;
        }
    }
#endregion
}
