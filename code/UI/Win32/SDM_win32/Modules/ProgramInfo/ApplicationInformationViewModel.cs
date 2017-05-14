using Shell32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
#region not unit-tested
    internal class ApplicationInformationViewModel
    {
        public ApplicationInformationViewModel( string filePath )
        {
            this._filePath = filePath;
            this.InitializeIcon();
            this.InitializeRemainingProperties();
        }


        public string Company { get; private set; }


        public string Description { get; private set; }


        public ImageSource Icon { get; private set; }


        //  --> https://blog.dotnetframework.org/2014/12/10/read-extended-properties-of-a-file-in-c/
        private void InitializeRemainingProperties()
        {
            var fileInfo = new FileInfo( this._filePath );
            var shell = new Shell();
            var folder = shell.NameSpace( fileInfo.DirectoryName );
            var file = folder.ParseName( fileInfo.Name );
            this.Company = folder.GetDetailsOf( file, COMPANY_INDEX );
            this.Description = folder.GetDetailsOf( file, FILE_DESCRIPTION_INDEX );
        }


        //  --> https://stackoverflow.com/questions/1127647/convert-system-drawing-icon-to-system-media-imagesource
        private void InitializeIcon()
        {
            var icon = System.Drawing.Icon.ExtractAssociatedIcon( this._filePath );
            var bmp = icon.ToBitmap();
            IntPtr hBitmap = bmp.GetHbitmap();
            var sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap( hBitmap, IntPtr.Zero, 
                                                                           Int32Rect.Empty, 
                                                                           sizeOptions );
            this.Icon = wpfBitmap;
        }


        private const int COMPANY_INDEX = 33;

        private const int FILE_DESCRIPTION_INDEX = 34;


        private string _filePath;
    }
#endregion
}
