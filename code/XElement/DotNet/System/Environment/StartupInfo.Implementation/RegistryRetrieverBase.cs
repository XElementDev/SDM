using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public abstract class RegistryRetrieverBase : IStartupInfo
    {
        public RegistryRetrieverBase() { }


        public IEnumerable<IProgramInfo> /*IStartupInfo.*/Retrieve()
        {
            var subKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using ( var key = Registry.LocalMachine.OpenSubKey( subKey ) )
            {
                var valueNames = key.GetValueNames();
            }
            
            throw new NotImplementedException();
        }
    }
#endregion
}
