using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
    // TODO
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            this.InitializeProperties();
        }


        public ImageSource ApplicationIcon { get; private set; }


        //public string ApplicationName { get; private set; }


        //  --> https://stackoverflow.com/questions/1127647/convert-system-drawing-icon-to-system-media-imagesource
        private void InitializeApplicationIcon()
        {
            var filePath = this.Model.ProgramInfo.FilePath;
            var icon = Icon.ExtractAssociatedIcon( filePath );
            var bmp = icon.ToBitmap();
            IntPtr hBitmap = bmp.GetHbitmap();
            var sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap( hBitmap, IntPtr.Zero,
                                                                           Int32Rect.Empty,
                                                                           sizeOptions );
            this.ApplicationIcon = wpfBitmap;
        }


        private void InitializeProperties()
        {
            this.InitializeApplicationIcon();
        }


        public Model Model { get; private set; }
    }
#endregion
}
