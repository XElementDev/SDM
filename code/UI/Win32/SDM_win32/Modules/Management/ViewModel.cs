namespace XElement.SDM.UI.Win32.Modules.Management
{
#region not unit-tested
    // TODO
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            var delayed = new ProgramInfos.ViewModel( model.DelayedProgramInfosModel );
            this.DelayedProgramInfosVM = delayed;

            var startup = new ProgramInfos.ViewModel( model.StartupProgramInfosModel );
            this.StartupProgramInfosVM = startup;
        }


        public ProgramInfos.ViewModel DelayedProgramInfosVM { get; private set; }


        public ProgramInfos.ViewModel StartupProgramInfosVM { get; private set; }
    }
#endregion
}
