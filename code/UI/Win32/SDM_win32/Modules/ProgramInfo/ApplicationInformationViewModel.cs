using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            this.InitializeDescription();
            this.InitializeIcon();
        }


        public string Description { get; private set; }


        public ImageSource Icon { get; private set; }


        //  --> https://blog.dotnetframework.org/2014/12/10/read-extended-properties-of-a-file-in-c/
        private void InitializeDescription()
        {
            var fileInfo = new FileInfo( this._filePath );

            var shell = new Shell();
            var folder = shell.NameSpace( fileInfo.DirectoryName );
            var file = folder.ParseName( fileInfo.Name );

            var list = new List<Tuple<int, string, string>>();
            for ( int i = 0 ; i < short.MaxValue ; ++i )
            {
                string header = folder.GetDetailsOf( null, i );
                var tuple = new Tuple<int, string, string>( i, header, null );
                list.Add( tuple );
            }

            for ( int i = 0 ; i < list.Count ; ++i )
            {
                var key = list[i].Item2;
                var value = folder.GetDetailsOf( file, i );
                var tuple = new Tuple<int, string, string>( i, key, value );
                list[i] = tuple;
            }

            var filtered = list.Where( t => t.Item3 != String.Empty ).ToList();
            this.Description = filtered.First( t => t.Item1 == FILE_DESCRIPTION ).Item3;
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


        private string _filePath;


        private const int FILE_DESCRIPTION = 34;
    }
#endregion
}
