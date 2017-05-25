using System.Collections.Generic;

namespace XElement.DotNet.System.Environment.Startup
{
    /*
     * interesting links:
     * https://blogs.msdn.microsoft.com/windowsstore/2012/06/08/listing-your-desktop-app-in-the-store/
     * https://xamltips.wordpress.com/2015/11/13/brokered-component-for-uwp-on-windows-10/
     * https://stackoverflow.com/questions/34694059/read-write-registery-key-file-in-uwp
     * https://stackoverflow.com/questions/35940683/uwp-app-start-automatically-at-startup
     */
    public interface IStartupInfo
    {
        IEnumerable<IProgramInfo> Retrieve();
    }
}
