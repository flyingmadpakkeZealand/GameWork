using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using XmlFramework;

namespace GameWork
{
    public static class Log
    {
        public static ILogger Logger { get; set; } = Init();

        private static ILogger Init()
        {
            ILogger log = null;
            XmlLayer root = XmlLayer.CreateRootLayer(PlaceHolderFileSystem.ConfigFilePath);
            ExtractionRaw raw = ExtractionRaw.OnOne(data => log = data[0].Data.ToLower() != "true" ? (ILogger)new DefaultLogger() : (ILogger)new EmptyLogger())
                .OnNone(()=> log = new EmptyLogger());

            root.ExtractIntoFromRaw(raw, "Log.Disable");
            return log;
        }
    }

    public interface ILogger
    {
        void TraceEvent(TraceEventType eventType, int id, [NotNull] string message);
    }

    internal class DefaultLogger : ILogger
    {
        private TraceSource _ts;

        public DefaultLogger()
        {
            _ts = new TraceSource("GameWorkLog", SourceLevels.All);
            _ts.Switch = new SourceSwitch("Default", "All");
            _ts.Listeners.Add(new ConsoleTraceListener());
        }

        public void TraceEvent(TraceEventType eventType, int id, string message)
        {
            _ts.TraceEvent(eventType, id, message);
        }
    }

    internal class EmptyLogger : ILogger
    {
        public void TraceEvent(TraceEventType eventType, int id, string message)
        {
            
        }
    }
}
