namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    // TODO
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this.DelayedProgramInfosVM = new ProgramInfos.ViewModel( model.DelayedProgramInfosModel );
            this.StartupProgramInfosVM = new ProgramInfos.ViewModel( model.StartupProgramInfosModel );
        }


        public ProgramInfos.ViewModel DelayedProgramInfosVM { get; private set; }


        public ProgramInfos.ViewModel StartupProgramInfosVM { get; private set; }
    }
#endregion
}
