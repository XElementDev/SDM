﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace XElement.DotNet.System.Environment.Startup.MefExtensions
{
#region not unit-tested
    [Export( typeof( IStartupInfo ) )]
    internal class AggregateAllRetriever : IStartupInfo
    {
        public AggregateAllRetriever()
        {
            this._allRetrievers = null;
        }


        public IEnumerable<IProgramInfo> Retrieve()
        {
            var listOfListOfResults = this._allRetrievers.Select( si => si.Retrieve() ).ToList();
            var listOfResults = listOfListOfResults.SelectMany( l => l ).ToList();
            return listOfResults;
        }


        [ImportMany( typeof( IStartupInfoInt ) )]
        private IEnumerable<IStartupInfo> _allRetrievers;
    }
#endregion
}
