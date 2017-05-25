using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Model.Serialization;

namespace XElement.SDM.UI.Win32.Model
{
#region not unit-tested
    //  --> TODO: Find better name
    [Export]
    internal class DataContainer : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private DataContainer() { }


        //public IEnumerable<IDelayedApplicationInfo> DelayedApplications { get; private set; }
        public IEnumerable<IProgramInfo> DelayedApplications { get; private set; }


        //void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        //{
        //    var delayedApplications = new List<IDelayedApplicationInfo>();
        //    delayedApplications.AddRange( this._localData.Data.DelayedApplications );
        //    // TODO: add global data
        //    this.DelayedApplications = delayedApplications;
        //}
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var delayedApplications = new List<IProgramInfo>();
            delayedApplications.AddRange( this._localData.Data.DelayedApplications );
            // TODO: add global data
            this.DelayedApplications = delayedApplications;
        }


        [Import]
        private LocalDataContainer _localData = null;
    }
#endregion
}
