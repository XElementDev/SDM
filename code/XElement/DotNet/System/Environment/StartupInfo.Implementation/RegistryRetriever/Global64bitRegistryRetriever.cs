﻿using Microsoft.Win32;
using XElement.DotNet.System.Environment.Startup.Technical;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class Global64bitRegistryRetriever : GlobalRegistryRetrieverBase, IStartupInfo
    {
        public Global64bitRegistryRetriever() { }


        protected override RegistryView /*GlobalRegistryRetrieverBase.*/Mode
        {
            get { return RegistryView.Registry64; }
        }
    }
#endregion
}
