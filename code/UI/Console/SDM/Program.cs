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

            Console.Read();

        }


        private static void OutputResults( IEnumerable<IProgramInfo> programInfos )
        {
            var jsonEncoded = new JavaScriptSerializer().Serialize( programInfos );
            Console.WriteLine( jsonEncoded );
        }
    }
}
