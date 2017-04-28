using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    //  --> https://stackoverflow.com/questions/13181009/c-sharp-get-list-of-application-which-runs-on-windows-startup-programatically
    public class RegistryRetrieverBase : IStartupInfo
    {
        public RegistryRetrieverBase() { }


        private IRegistryOrigin CreateOriginFrom( KeyValuePair<string, string> kvp )
        {
            var origin = new RegistryOrigin
            {
                KeyName = kvp.Key, 
                Location = RegistryRetrieverBase.SUB_KEY
            };
            return origin;
        }


        private IProgramInfo CreateProgramInfoFrom( KeyValuePair<string, string> kvp )
        {
            var value = kvp.Value.Replace( "\"", String.Empty );
            var pattern = ".exe";
            var index = value.IndexOf( pattern );
            var argument = value.Substring( index + pattern.Length ).Trim( ' ' );
            var filePath = value.Substring( 0, index + pattern.Length );
            var programInfo = new ProgramInfo
            {
                Argument = argument, 
                FilePath = filePath, 
                Origin = this.CreateOriginFrom( kvp )
            };
            return programInfo;
        }


        private IDictionary<string, string> GetDictionaryFromRegistryKey( RegistryKey registryKey )
        {
            var dict = new Dictionary<string, string>();

            var valueNames = registryKey.GetValueNames();
            foreach ( var dictKey in valueNames )
            {
                if ( registryKey.GetValueKind( dictKey ) == RegistryValueKind.String )
                {
                    var dictValue = (string)registryKey.GetValue( dictKey );
                    dict.Add( dictKey, dictValue );
                }
            }

            return dict;
        }


        private IDictionary<string, string> GetRegistryEntries()
        {
            IDictionary<string, string> registryEntries = new Dictionary<string, string>();

            using ( var key = Registry.LocalMachine.OpenSubKey( RegistryRetrieverBase.SUB_KEY ) )
            {
                registryEntries = this.GetDictionaryFromRegistryKey( key );
            }

            return registryEntries;
        }


        public IEnumerable<IProgramInfo> /*IStartupInfo.*/Retrieve()
        {
            var registryEntries = this.GetRegistryEntries();
            var programInfos = registryEntries.Select( this.CreateProgramInfoFrom ).ToList();
            return programInfos;
        }


        private const string SUB_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
    }
#endregion
}
