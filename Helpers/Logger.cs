using System.Text.Json;

namespace backend_dotnet.Helpers
{
    public static class Logger
    {
        public static void Log(object obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            Console.WriteLine(json);
        }
    }
}
