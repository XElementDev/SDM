using System.Collections.Generic;

namespace XElement.SDM.DelayLogic
{
    public interface IDelayManager
    {
        IEnumerable<IDelayInfo> DelayedStartups { get; set; }


        void Start();
    }
}
