using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.WinConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            var globalFsRetriever = new GlobalFileSystemRetriever();
            var globalFsResults = globalFsRetriever.Retrieve();
            OutputResults( globalFsResults );

            var localFsRetriever = new LocalFileSystemRetriever();
            var localFsResults = localFsRetriever.Retrieve();
            OutputResults( localFsResults );

            var globalRegistryRetriever32 = new Global32bitRegistryRetriever();
            var globalRegistry32Results = globalRegistryRetriever32.Retrieve();
            OutputResults( globalRegistry32Results );

            var globalRegistryRetriever64 = new Global64bitRegistryRetriever();
            var globalRegistry64Results = globalRegistryRetriever64.Retrieve();
            OutputResults( globalRegistry64Results );

            var localRegistryRetriever32 = new Local32bitRegistryRetriever();
            var localRegistry32Results = localRegistryRetriever32.Retrieve();
            OutputResults( localRegistry32Results );

            var localRegistryRetriever64 = new Local64bitRegistryRetriever();
            var localRegistry64Results = localRegistryRetriever64.Retrieve();
            OutputResults( localRegistry64Results );

            Console.Read();
        }


        private static void OutputResults( IEnumerable<IProgramInfo> programInfos )
        {
            //  --> https://stackoverflow.com/questions/6201529/turn-c-sharp-object-into-a-json-string-in-net-4
            var jsonEncoded = new JavaScriptSerializer().Serialize( programInfos );
            Console.WriteLine( jsonEncoded );
        }
    }
}
