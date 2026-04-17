using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    /// <summary>
    /// Класс, представляющий данные о событии мониторинга
    /// </summary>
    public class MetricData
    {
        //Название метрики
        public string MetricName { get; }
        // Зарегистрированное значение
        public double Value { get; }
        // Критический порог
        public double Threshold { get; }
        public DateTime Timestamp { get; }

        public MetricData(string metricName, double value, double threshold, DateTime timestamp)
        {
            MetricName = metricName ?? throw new ArgumentNullException(nameof(metricName));
            Value = value;
            Threshold = threshold;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"Metric: {MetricName}, Value: {Value} (Threshold: {Threshold})";
        }
    }
}
