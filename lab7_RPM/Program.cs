using lab7_RPM;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Система мониторинга и оповещения о событиях\n");

        // 1. Создаем монитор событий (издатель)
        var monitor = new EventMonitor();

        // 2. Создаем обработчики (подписчики) с различными стратегиями форматирования

        // Обработчик для консоли с текстовым форматом
        var consoleTextHandler = new ConsoleHandler(new TextFormatStrategy());

        // Обработчик для консоли с JSON форматом
        var consoleJsonHandler = new ConsoleHandler(new JsonFormatStrategy());

        // 3. Подписываем обработчики на событие монитора
        monitor.OnMetricExceeded += consoleTextHandler.ProcessEvent;
        monitor.OnMetricExceeded += consoleJsonHandler.ProcessEvent;

        Console.WriteLine("Подписчики зарегистрированы:");
        Console.WriteLine("- ConsoleHandler (TextFormat)");
        Console.WriteLine("- ConsoleHandler (JsonFormat)");

        // 4. Демонстрация работы системы
        Console.WriteLine("=== Начало мониторинга ===\n");

        // Моделируем проверку метрик
        Console.WriteLine(" Проверка 1: Загрузка CPU");
        monitor.CheckMetric("CPU_Load", 85.5, 80.0);

        Console.WriteLine("\n Проверка 2: Использование памяти ");
        monitor.CheckMetric("Memory_Usage", 75.2, 90.0);

        Console.WriteLine("\n Проверка 3: Сетевая активность ");
        monitor.CheckMetric("Network_Traffic", 150.0, 100.0);

        Console.WriteLine("\n Проверка 4: Загрузка CPU (снова)");
        monitor.CheckMetric("CPU_Load", 95.0, 80.0);

        Console.WriteLine("\n Мониторинг завершен ");

        // 5. Демонстрация смены стратегии во время выполнения
        Console.WriteLine("\n Демонстрация смены стратегии");
        Console.WriteLine("Меняем стратегию у consoleTextHandler с TextFormat на HtmlFormat\n");

        monitor.CheckMetric("Test_Metric", 120.0, 100.0);

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}