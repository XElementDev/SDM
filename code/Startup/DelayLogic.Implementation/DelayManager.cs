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


        private int MinutesRunning
        {
            get { return this._intervalInMinutes * this._elapsedCounter; }
        }


        public void /*IDelayManager.*/Start()
        {
            this._elapsedCounter = 0;
            this._timer.Start();
        }


        private static void StartExecutable( IDelayInfo delayedStartup )
        {
            var filePath = delayedStartup.ProgramInfo.FilePath;
            var arguments = delayedStartup.ProgramInfo.Argument;
            var startInfo = new ProcessStartInfo( filePath, arguments );
            Process.Start( startInfo );
        }


        private void TimerElapsed()
        {
            ++this._elapsedCounter;

            foreach ( var delayInfo in this.DelayedStartups )
            {
                if ( this.MinutesRunning == delayInfo.DelayInMinutes )
                {
                    DelayManager.StartExecutable( delayInfo );
                }
            }
        }


        private const double ONE_MINUTE = 60000d;

        private int _elapsedCounter;

        private int _intervalInMinutes;

        private Timer _timer;
    }
#endregion
}
