﻿using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;
using XElement.SDM.UI.Win32.Model;

namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    [Export]
    internal class ModelDependencies
    {
        [ImportingConstructor]
        public ModelDependencies() { }


        [Import]
        public DataContainer DataContainer { get; set; }


        [Import]
        public IFactory<IProgramLogic, IProgramInfo> ProgramLogicFactory { get; set; }
    }
#endregion
}
