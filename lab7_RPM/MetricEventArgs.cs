using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    public class MetricEventArgs : EventArgs
    {
        public string EventType { get; }
        public MetricData Data { get; }

        public MetricEventArgs(string eventType, MetricData data)
        {
            EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
