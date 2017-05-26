using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;

namespace XElement.SDM.UI.Win32.Model.AutoSave
{
#region not unit-tested
    [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model()
        {
            this.SubscribeEvents();
        }


        private void OnApplicationClosing()
        {
            foreach ( IAutoSaveTarget autoSaveTarget in this._autoSaveTargets )
            {
                autoSaveTarget.Persist();
            }
        }


        private void SubscribeEvents()
        {
            var app = Application.Current;
            app.Startup += ( s1, e1 ) => 
            {
                app.MainWindow.Closed += ( s2, e2 ) => this.OnApplicationClosing();
            };
        }


        [ImportMany]
        private IEnumerable<IAutoSaveTarget> _autoSaveTargets = null;
    }
#endregion
}
