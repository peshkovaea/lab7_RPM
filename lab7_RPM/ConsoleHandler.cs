using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy)
        {
        }

        protected override string FormatMessage(string type, MetricData data)
        {
            
            string message = $"[{type}] {data.MetricName}: {data.Value} (Threshold: {data.Threshold})";// форматируем сообщение с использованием стратегии
            return _formatStrategy.Format(message, data.Timestamp);
        }

        protected override void SendMessage(string message)
        {
            Console.WriteLine($"[ConsoleHandler]: {message}");
        }

        protected override void LogResult()
        {
            Console.WriteLine("[ConsoleHandler]: Уведомление отправлено в консоль");
        }
    }
}
