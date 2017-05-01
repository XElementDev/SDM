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

            var registryRetriever32 = new Global32bitRegistryRetriever();
            var registry32Results = registryRetriever32.Retrieve();
            OutputResults( registry32Results );

            var registryRetriever64 = new Global64bitRegistryRetriever();
            var registry64Results = registryRetriever64.Retrieve();
            OutputResults( registry64Results );

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
