using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    public class EventMonitor
    {
        public event MetricEventHandler? OnMetricExceeded;

        public void CheckMetric(string metricName, double value, double threshold)
        {
            Console.WriteLine($"[Monitor]: Checking {metricName} ({value} vs {threshold})");
            if (value > threshold)
            {
                var eventData = new MetricData(metricName, value, threshold, DateTime.Now); //создание данных метрики
                OnMetricExceeded?.Invoke(new MetricEventArgs(eventType: metricName + "_Exceeded", data: eventData)); //проверка есть ли подписчики
            }
        }
    }
}
