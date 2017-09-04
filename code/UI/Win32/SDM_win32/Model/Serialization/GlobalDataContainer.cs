using System;
using System.ComponentModel.Composition;
using XElement.SDM.UI.Win32.Model.AutoSave;

namespace XElement.SDM.UI.Win32.Model.Serialization
{
#region not unit-tested
    [Export]
    [Export( typeof( IAutoSaveTarget ) )]
    internal class GlobalDataContainer : AbstractDataContainer, IAutoSaveTarget
    {
        [ImportingConstructor]
        public GlobalDataContainer() : base() { }


        protected override Environment.SpecialFolder GetSpecialFolder()
        {
            return Environment.SpecialFolder.CommonApplicationData;
        }
    }
#endregion
}
