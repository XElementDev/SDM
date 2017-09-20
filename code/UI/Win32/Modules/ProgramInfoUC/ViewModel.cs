using System;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
#region not unit-tested
    //TODO: Visiualize that a program has already been started
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            this.Initialize();
        }


        public ApplicationInformationViewModel AppInfoVM { get; private set; }


        public bool HasCmdArguments { get; private set; }


        private void Initialize()
        {
            var filePath = this.Model.ProgramInfo.StartInfo.FilePath;
            this.AppInfoVM = new ApplicationInformationViewModel( filePath );

            var cmdArgs = this.Model.ProgramInfo.StartInfo.Arguments.Trim() ?? String.Empty;
            this.HasCmdArguments = cmdArgs != String.Empty;

            this.InitializeAdminPrivilegesInfo();
        }


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
