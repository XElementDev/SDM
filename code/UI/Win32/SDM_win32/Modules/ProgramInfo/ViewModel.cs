namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
    // TODO
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
        }


        //public Icon ApplicationIcon { get; private set; }


        public string ApplicationName { get; private set; }


        public Model Model { get; private set; }
    }
#endregion
}
