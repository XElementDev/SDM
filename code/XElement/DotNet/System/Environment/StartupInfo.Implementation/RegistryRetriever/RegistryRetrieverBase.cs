using Microsoft.Win32;
using System;
using System.Collections.Generic;
using XElement.DotNet.System.Environment.Startup.DataTypes;

namespace XElement.DotNet.System.Environment.Startup.Technical
{
#region not unit-tested
    //  --> https://stackoverflow.com/questions/13181009/c-sharp-get-list-of-application-which-runs-on-windows-startup-programatically
    public abstract class RegistryRetrieverBase : RetrieverBase<KeyValuePair<string, string>>, 
                                                  IStartupInfo
    {
        public RegistryRetrieverBase() { }


        protected override IOrigin /*RetrieverBase<T1>.*/CreateOriginFrom( KeyValuePair<string, string> kvp )
        {
            IRegistryOrigin origin = new RegistryOrigin
            {
                IsForAllUsers = this.IsForAllUsers, 
                Mode = this.Mode, 
                SubKey = RegistryRetrieverBase.SUB_KEY, 
                TopLevelNode = this.TopLevelNode, 
                ValueName = kvp.Key
            };
            return origin;
        }


        protected override IStartInfo /*RetrieverBase<T1>.*/CreateStartInfoFrom( KeyValuePair<string, string> kvp )
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


        protected override IEnumerable<KeyValuePair<string, string>> /*RetrieverBase<T1>.*/GetEntitiesForStartInfoCreation()
        {
            return this.GetRegistryEntries();
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


        protected abstract RegistryHive TopLevelNode { get; }


        private const string SUB_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
    }
#endregion
}
