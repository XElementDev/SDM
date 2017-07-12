﻿using Microsoft.Win32;

namespace XElement.DotNet.System.Environment.Startup
{
#region not unit-tested
    public class Global32bitRegistryRetriever : GlobalRegistryRetrieverBase, IStartupInfo
    {
        public Global32bitRegistryRetriever() { }


        protected override RegistryView /*GlobalRegistryRetrieverBase.*/Mode
        {
            get { return RegistryView.Registry32; }
        }
    }
#endregion
}
