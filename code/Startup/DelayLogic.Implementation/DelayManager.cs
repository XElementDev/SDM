using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace XElement.SDM.DelayLogic
{
#region not unit-tested
    public class DelayManager : IDelayManager
    {
        public DelayManager()
        {
            this._intervalInMinutes = (int)DelayManager.ONE_MINUTE;
            this._timer = new Timer( this._intervalInMinutes );
            this._timer.Elapsed += ( s, e ) => this.TimerElapsed();
        }


        public IEnumerable<IDelayInfo> /*IDelayManager.*/DelayedStartups { get; set; }


        public void /*IDelayManager.*/Start()
        {
            this._minutesRunning = 0;
            this._timer.Start();
        }


        private static void StartExecutable( IDelayInfo delayedStartup )
        {
            var filePath = delayedStartup.StartInfo.FilePath;
            var arguments = delayedStartup.StartInfo.Arguments;
            var processStartInfo = new ProcessStartInfo( filePath, arguments );
            Process.Start( processStartInfo );
        }


        private void TimerElapsed()
        {
            ++this._minutesRunning;

            foreach ( var delayInfo in this.DelayedStartups )
            {
                if ( this._minutesRunning == delayInfo.DelayInMinutes )
                {
                    DelayManager.StartExecutable( delayInfo );
                }
            }
        }


        private const double ONE_MINUTE = 60000d;


        private int _intervalInMinutes;

        private int _minutesRunning;

        private Timer _timer;
    }
#endregion
}
