using System.ComponentModel.Composition;
using System.Reflection;

namespace XElement.SDM.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class ApplicationInfoAccessor
    {
        [ImportingConstructor]
        private ApplicationInfoAccessor()
        {
            this.FilePath = this.GetFilePath();
        }


        public string FilePath { get; private set; }


        private string GetFilePath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
#endregion
}
