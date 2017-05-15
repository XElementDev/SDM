﻿using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.ManagementLogic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IFactory<IProgramLogic, IProgramInfo> ) )]
    internal class ProgramLogicFactory : global::XElement.SDM.ManagementLogic.ProgramLogicFactory { }
#endregion
}