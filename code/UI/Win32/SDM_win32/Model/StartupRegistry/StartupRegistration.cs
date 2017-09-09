using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.ManagementLogic;
using XElement.SDM.UI.Win32.Model.StartupRegistry;

namespace XElement.SDM.UI.Win32.Model
{
#region not unit-tested
    //TODO: DRY w.r.t. StartupInfo project
    [Export]
    internal class StartupRegistration : IPartImportsSatisfiedNotification
    {
        private StartupRegistration()
        {
            this._appInfoAccessor = null;
            this._programLogicFactory = null;
            this._startupInfo = null;
        }


        private IOrigin CreateOrigin()
        {
            string localAppData = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
            string windowsStartupFolderPath = Path.Combine( localAppData, "Microsoft", "Windows", 
                                                            "Start Menu", "Programs", "Startup" );
            string location = Path.Combine( windowsStartupFolderPath, "SDM.lnk" );

            var origin = new FileOriginDTO
            {
                IsForAllUsers = false, 
                Location = location
            };
            return origin;
        }


        private IProgramInfo CreateProgramInfo()
        {
            var programInfo = new ProgramInfoDTO
            {
                Origin = this.CreateOrigin(), 
                StartInfo = this.CreateStartInfo()
            };
            return programInfo;
        }


        private IStartInfo CreateStartInfo()
        {
            var startInfo = new StartInfoDTO
            {
                Arguments = String.Empty, 
                FilePath = this._appInfoAccessor.FilePath
            };
            return startInfo;
        }


        private bool IsStartup()
        {
            var programInfos = this._startupInfo.Retrieve();
            Func<string, bool> doFilePathsMatch = path => path == this._appInfoAccessor.FilePath;
            bool isStartup = programInfos.Any( pi => doFilePathsMatch( pi.StartInfo.FilePath ) );
            return isStartup;
        }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.TryRegister();
        }


        private void Register()
        {
            var programInfo = this.CreateProgramInfo();
            var programLogic = this._programLogicFactory.Get( programInfo );
            programLogic.PromoteStartup();
        }


        private void TryRegister()
        {
            if ( !this.IsStartup() )
            {
                this.Register();
            }
        }


        [Import]
        private ApplicationInfoAccessor _appInfoAccessor;

        [Import]
        private IFactory<IProgramLogic, IProgramInfo> _programLogicFactory;

        [Import]
        private IStartupInfo _startupInfo;
    }
#endregion
}
