using System;
using System.Windows;
using System.Windows.Controls;

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
            var part1 = "IF YOU CLOSE THIS APPLICATION";
            var part2 = "ALL MANAGED APPLICATIONS THAT HAVE NOT BEEN STARTED YET WON'T BE STARTED.";
            var part3 = "ARE YOU SURE?";
            var message = $"<{part1}, {part2}{Environment.NewLine}{part3}>";
            result = MessageBox.Show( this._parentWindow, message, string.Empty, 
                                      MessageBoxButton.YesNo, MessageBoxImage.Warning );

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


        private TaskbarIcon.ViewModel TaskbarIconVM
        {
            get { return this.DataContext as TaskbarIcon.ViewModel; }
        }


        private Window _parentWindow;
    }
#endregion
}
