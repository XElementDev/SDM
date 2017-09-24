using System.ComponentModel.Composition;
using System.Windows;

namespace XElement.SDM.UI.Win32.Modules.TaskbarIcon
{
#region not unit-tested
    [Export]
    internal class TaskbarIconModel
    {
        [ImportingConstructor]
        private TaskbarIconModel() { }


        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
#endregion
}
