using System.Windows;
using System.Windows.Controls;
using XElement.SDM.UI.Win32.Localization;

namespace XElement.SDM.UI.Win32.Modules
{
#region not unit-tested
    public partial class TaskbarIconUC : UserControl
    {
        public TaskbarIconUC()
        {
            this.InitializeComponent();
            this.Loaded += ( s, e ) => this.InitializeParentWindow();
        }


        private void ExitMenuItem_Click( object sender, RoutedEventArgs e )
        {
            var result = MessageBoxResult.No;
            string message = Locale.TaskbarIconUC_ExitConfirmation_Text;
            var caption = Locale.TaskbarIconUC_ExitConfirmation_Caption;
            result = MessageBox.Show( this._parentWindow, message, caption, MessageBoxButton.YesNo, 
                                      MessageBoxImage.Warning );

            if (result == MessageBoxResult.Yes)
            {
                this.TaskbarIconVM.ExitApplicationCommand.Execute( "irrelevant" );
            }
        }


        private void InitializeParentWindow()
        {
            FrameworkElement currentFrameworkElement = this;
            while( !(currentFrameworkElement.Parent is Window) )
            {
                var parent = currentFrameworkElement.Parent;
                currentFrameworkElement = parent as FrameworkElement;
            }
            var parentWindow = currentFrameworkElement.Parent as Window;
            this._parentWindow = parentWindow;
        }


        private TaskbarIcon.TaskbarIconViewModel TaskbarIconVM
        {
            get { return this.DataContext as TaskbarIcon.TaskbarIconViewModel; }
        }


        private Window _parentWindow;
    }
#endregion
}
