using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.SDM.UI.Win32.Model.Events;

namespace XElement.SDM.UI.Win32.Model.AutoSave
{
#region not unit-tested
    [Export]
    internal class AutoSaveModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public AutoSaveModel( AutoSaveModelDependencies dependencies )
        {
            this._dependencies = dependencies;
        }


        private void OnApplicationClosing()
        {
            foreach ( IAutoSaveTarget autoSaveTarget in this._autoSaveTargets )
            {
                autoSaveTarget.Persist();
            }
        }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            var appClosingEvent = this._dependencies.EventAggregator.GetEvent<ApplicationClosing>();
            appClosingEvent.Subscribe( this.OnApplicationClosing );
        }


        [ImportMany]
        private IEnumerable<IAutoSaveTarget> _autoSaveTargets = null;


        private AutoSaveModelDependencies _dependencies;
    }
#endregion
}
