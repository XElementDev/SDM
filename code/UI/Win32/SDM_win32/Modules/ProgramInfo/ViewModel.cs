namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
    // TODO
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            var filePath = this.Model.ProgramInfo.FilePath;
            this.AppInfoVM = new ApplicationInformationViewModel( filePath );
        }


        public ApplicationInformationViewModel AppInfoVM { get; private set; }


        public Model Model { get; private set; }
    }
#endregion
}
