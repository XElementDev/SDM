using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using XElement.DotNet.System.Environment.Startup;

namespace XElement.SDM.UI.Win32.Proxy.Logic
{
#region not unit-tested
    //TODO: DRY w.r.t. CSH project
    internal class Logger
    {
        private Logger()
        {
            this.InitializeEventLogger();
            this._serializer = new JavaScriptSerializer();
        }


        public static Logger Get()
        {
            if ( Logger._singleton == null )
            {
                Logger._singleton = new Logger();
            }
            return Logger._singleton;
        }


        public string GetLogRepresentationOf( IProgramInfo programInfo )
        {
            var stringRepresentation = this._serializer.Serialize( programInfo );
            return stringRepresentation;
        }


        private void InitializeEventLogger()
        {
            if ( !EventLog.SourceExists( Logger.EVENT_SOURCE ) )
            {
                EventLog.CreateEventSource( Logger.EVENT_SOURCE, Logger.LOG_NAME );
            }

            this._eventLog = new EventLog();
            this._eventLog.Source = Logger.EVENT_SOURCE;
            this._eventLog.Log = Logger.LOG_NAME;
        }


        public void Log( string logMessage )
        {
            this.LogWithTimestamp( logMessage );
        }


        private void LogWithTimestamp( string logMessage )
        {
            var dateTime = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.ffff" );
            var eventLogMessage = $"{dateTime}  Server  {logMessage}";

            this._eventLog.WriteEntry( eventLogMessage, EventLogEntryType.Information );
            Console.WriteLine( eventLogMessage );
        }


        private const string EVENT_SOURCE = "Management_Proxy";
        private const string LOG_NAME = "SDM";


        private EventLog _eventLog;
        private JavaScriptSerializer _serializer;
        private static Logger _singleton;
    }
#endregion
}
