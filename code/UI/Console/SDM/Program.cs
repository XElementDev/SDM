using System;
using System.Collections.Generic;
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


        private static void OutputResult( IProgramInfo programInfo )
        {
            var output = $"ProgramInfo {{ argument = {programInfo.Argument}, " + 
                         $"filePath = {programInfo.FilePath}, " + 
                         $"origin = Origin {{ location = {programInfo.Origin.Location} }} }}";
            Console.WriteLine( output );
        }


        private static void OutputResults( IEnumerable<IProgramInfo> programInfos )
        {
            foreach ( var programInfo in programInfos )
            {
                OutputResult( programInfo );
            }
        }
    }
}
