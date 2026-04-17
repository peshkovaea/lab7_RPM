using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_RPM
{
    public interface IFormatStrategy //интерфейс стратегии форматирования
    {
        string Format(string message, DateTime timestamp);
    }
}
