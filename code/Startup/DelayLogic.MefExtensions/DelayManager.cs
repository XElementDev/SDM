using System.ComponentModel.Composition;

namespace XElement.SDM.DelayLogic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IDelayManager ) )]
    internal class DelayManager : global::XElement.SDM.DelayLogic.DelayManager { }
#endregion
}
