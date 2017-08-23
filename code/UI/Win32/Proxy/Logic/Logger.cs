using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.UI.Win32.Proxy.Serialization;

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
            if ( _singleton == null )
            {
                _singleton = new Logger();
            }
            return _singleton;
        }


        public string GetLogRepresentationOf( IProxyParameters proxyParams )
        {
            var stringRepresentation = this._serializer.Serialize( proxyParams );
            return stringRepresentation;
        }


        private void InitializeEventLogger()
        {
            if ( !EventLog.SourceExists( EVENT_SOURCE ) )
            {
                EventLog.CreateEventSource( EVENT_SOURCE, LOG_NAME );
            }

            this._eventLog = new EventLog();
            this._eventLog.Source = EVENT_SOURCE;
            this._eventLog.Log = LOG_NAME;
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
