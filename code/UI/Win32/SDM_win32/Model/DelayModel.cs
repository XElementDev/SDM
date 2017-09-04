using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.DelayLogic;

namespace XElement.SDM.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class DelayModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public DelayModel() { }


        //TODO: Check/make sure that only deserialized applications are started here.
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var delayedStartups = new List<IDelayInfo>();
            foreach ( var programInfo in this._dataContainer.DelayedApplications )
            {
                var delayInfo = new DelayModel.DelayInfo
                {
                    DelayInMinutes = 1,
                    StartInfo = programInfo.StartInfo
                };
                delayedStartups.Add( delayInfo );
            }
            this._delayManager.DelayedStartups = delayedStartups;
            this._delayManager.Start();
        }


        [Import]
        private DataContainer _dataContainer = null;

        [Import]
        private IDelayManager _delayManager = null;


        private class DelayInfo : IDelayInfo
        {
            public int /*IDelayInfo.*/DelayInMinutes { get; set; }


            public IStartInfo /*IDelayInfo.*/StartInfo { get; set; }
        }
    }
#endregion
}
