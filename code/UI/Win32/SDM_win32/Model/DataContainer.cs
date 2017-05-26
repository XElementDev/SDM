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
        private IEnumerable<IProgramInfo> _delayedApplications;

        public IEnumerable<IProgramInfo> DelayedApplications
        {
            get { return this._delayedApplications; }
            set
            {
                this._delayedApplications = value;
                this.UpdatePrivateDataContainers();
            }
        }


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


        private void UpdatePrivateDataContainers()
        {
            this._localData.Data = new Data { DelayedApplications = this.DelayedApplications };
        }


        [Import]
        private LocalDataContainer _localData = null;
    }
#endregion
}
