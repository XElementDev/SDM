﻿using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.DelayLogic
{
    public interface IDelayInfo
    {
        int DelayInMinutes { get; }


        IStartInfo StartInfo { get; }
    }
}
