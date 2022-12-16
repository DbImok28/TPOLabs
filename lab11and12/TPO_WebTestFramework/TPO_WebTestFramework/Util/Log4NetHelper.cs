using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net;

namespace TPO_WebTestFramework.Util
{
    public class Log4NetHelper
    {
        private static ILog? Logger = null;
        private static ConsoleAppender? ConsoleAppender = null;
        private static FileAppender? FileAppender = null;
        private static string _layout = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";

        public static string Layout
        {
            set { _layout = value; }
        }

        private static PatternLayout GetPatternLayout()
        {
            var patterLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patterLayout.ActivateOptions();
            return patterLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.Error
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log",
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        public static ILog GetLogger(Type type)
        {
            ConsoleAppender ??= GetConsoleAppender();
            FileAppender ??= GetFileAppender();

            if (Logger != null)
                return Logger;

            BasicConfigurator.Configure(ConsoleAppender, FileAppender);
            Logger = LogManager.GetLogger(type);
            return Logger;
        }
    }
}
