using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy; //текущая стратегия

        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void SetStrategy(IFormatStrategy strategy)//устанавливаем стратегию 
        {
            _formatStrategy = strategy;
        }

        public void ProcessEvent(MetricEventArgs e)
        {
            var message = FormatMessage(e.EventType, e.Data); //форматируем по стратегии
            SendMessage(message); //отправляем уведомление
            LogResult(); //логируем результат (опционально)
        }

        // Абстрактные методы, которые должны быть реализованы в подклассах
        protected abstract string FormatMessage(string type, MetricData data);
        protected abstract void SendMessage(string message);
        protected abstract void LogResult();
    }
}
