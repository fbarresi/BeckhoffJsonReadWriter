using log4net;
using TFU001;

namespace TFU003
{
    public static class LoggerFactory
    {
        public static ILog GetLogger()
        {
            return LogManager.GetLogger(Constants.LoggingRepositoryName);
        }
    }
}