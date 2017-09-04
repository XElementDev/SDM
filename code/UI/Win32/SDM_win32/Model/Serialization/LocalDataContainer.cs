using System;
using System.ComponentModel.Composition;
using XElement.SDM.UI.Win32.Model.AutoSave;

namespace XElement.SDM.UI.Win32.Model.Serialization
{
#region not unit-tested
    [Export]
    [Export( typeof( IAutoSaveTarget ) )]
    internal class LocalDataContainer : AbstractDataContainer, IAutoSaveTarget
    {
        [ImportingConstructor]
        public LocalDataContainer() : base() { }


        protected override Environment.SpecialFolder GetSpecialFolder()
        {
            return Environment.SpecialFolder.LocalApplicationData;
        }
    }
#endregion
}
