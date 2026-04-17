using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    public class FileHandler : EventHandlerBase
    {
        private readonly string _filePath;//шаблонный метод для конкретного файйла

        public FileHandler(IFormatStrategy strategy, string filePath) : base(strategy) //передает стратегию форматирования в базовый класс и сохраняет путь к  файла
        {
            _filePath = filePath;
        }

        protected override string FormatMessage(string type, MetricData data)
        {
           
            string message = $"[{type}] {data.MetricName}: {data.Value} (Threshold: {data.Threshold})"; // форматируем сообщение с использованием стратегии
            return _formatStrategy.Format(message, data.Timestamp);
        }

        protected override void SendMessage(string message)
        {
            
            File.AppendAllText(_filePath, message + Environment.NewLine);// запись сообщения в файл
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[FileHandler]: Уведомление записано в файл: {_filePath}");
        }
    }
}
