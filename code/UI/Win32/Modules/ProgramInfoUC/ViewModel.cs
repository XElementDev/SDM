namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
    // TODO
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            var filePath = this.Model.ProgramInfo.StartInfo.FilePath;
            this.AppInfoVM = new ApplicationInformationViewModel( filePath );
            this.InitializeAdminPrivilegesInfo();
        }


        public ApplicationInformationViewModel AppInfoVM { get; private set; }


        private void InitializeAdminPrivilegesInfo()
        {
            this.ShowAllUsersImage = this.Model.ProgramInfo.Origin.IsForAllUsers;
            this.ShowCurrentUserImage = !this.ShowAllUsersImage;
        }


        public Model Model { get; private set; }


        public bool ShowAllUsersImage { get; private set; }


        public bool ShowCurrentUserImage { get; private set; }
    }
#endregion
}
