using Microsoft.Extensions.Logging;

namespace Phase03_FullTextSearchRefactor.UI
{
    internal static class Logger
    {
        private static readonly ILoggerFactory LoggerFactory;
        private static readonly ILogger LoggerInstance;

        static Logger()
        {
            LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            LoggerInstance = LoggerFactory.CreateLogger("ApplicationLogger");
        }

        public static void LogError(string message)
        {
            LoggerInstance.LogError(message);
        }

        public static void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}