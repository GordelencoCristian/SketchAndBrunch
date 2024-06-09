using System.Text.Json;

namespace BackOffice.Client
{
    public static class ConsoleLog
    {
        public static void LogAsJson<T>(string logName, T obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine($"{logName} {json}");
        }

        public static void LogAsJson(string logName)
        {
            Console.WriteLine($"{logName}");
        }
    }
}
