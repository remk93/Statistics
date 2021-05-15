using System;
using System.Diagnostics;

namespace Statistics.Core.Helpers
{
    public class LogStopwatcher : IDisposable
    {
        private readonly Stopwatch _stopwatcher;
        private readonly Action<TimeSpan> _timeAction;

        public LogStopwatcher(Action<TimeSpan> timeAction)
        {
            _timeAction = timeAction;
            _stopwatcher = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatcher.Stop();
            _timeAction(_stopwatcher.Elapsed);
        }
    }
}
