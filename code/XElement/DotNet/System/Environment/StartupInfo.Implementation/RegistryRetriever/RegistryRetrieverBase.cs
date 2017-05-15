using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using XElement.DotNet.System.Environment.Startup.DataTypes;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    //  --> https://stackoverflow.com/questions/13181009/c-sharp-get-list-of-application-which-runs-on-windows-startup-programatically
    public abstract class RegistryRetrieverBase : IStartupInfo
    {
        public RegistryRetrieverBase() { }


        private IRegistryOrigin CreateOriginFrom( KeyValuePair<string, string> kvp )
        {
            var origin = new RegistryOrigin
            {
                Mode = this.Mode, 
                SubKey = RegistryRetrieverBase.SUB_KEY, 
                TopLevelNode = this.TopLevelNode, 
                ValueName = kvp.Key
            };
            return origin;
        }


        private IProgramInfo CreateProgramInfoFrom( KeyValuePair<string, string> kvp )
        {
            var programInfo = new ProgramInfo
            {
                Origin = this.CreateOriginFrom( kvp ), 
                StartInfo = this.CreateStartInfoFrom( kvp )
            };
            return programInfo;
        }


        private IStartInfo CreateStartInfoFrom( KeyValuePair<string, string> kvp )
        {
            var value = kvp.Value.Replace( "\"", String.Empty );
            var pattern = ".exe";
            var index = value.IndexOf( pattern );
            var arguments = value.Substring( index + pattern.Length ).Trim( ' ' );
            var filePath = value.Substring( 0, index + pattern.Length );

            var startInfo = new StartInfo
            {
                Arguments = arguments,
                FilePath = filePath
            };
            return startInfo;
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

            using ( var baseKey = RegistryKey.OpenBaseKey( this.TopLevelNode, this.Mode ) )
            {
                using ( RegistryKey regKey = baseKey.OpenSubKey( RegistryRetrieverBase.SUB_KEY ) )
                {
                    registryEntries = this.GetDictionaryFromRegistryKey( regKey );
                }
            }

            return registryEntries;
        }


        protected abstract RegistryView Mode { get; }


        public IEnumerable<IProgramInfo> /*IStartupInfo.*/Retrieve()
        {
            var registryEntries = this.GetRegistryEntries();
            var programInfos = registryEntries.Select( this.CreateProgramInfoFrom ).ToList();
            return programInfos;
        }


        protected abstract RegistryHive TopLevelNode { get; }


        private const string SUB_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
    }
#endregion
}
