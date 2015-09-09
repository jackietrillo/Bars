using NLog;
using Bars.Core.Extensions;
using System;

namespace Bars.Core.Logging
{
    public class Logger : ILogger
    {
        private static NLog.Logger _logger;

        public Logger(string name)
        {
           _logger = LogManager.GetLogger(name);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Debug(message.FormatWith(message, args));
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(message.FormatWith(args));
        }

        public void Error(Exception ex, string message, params object[] args)
        {
            _logger.Error(ex, message.FormatWith(args));
        }

        public void Fatal(string message, params object[] args)
        {
            _logger.Fatal(message.FormatWith(args));
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message.FormatWith(args));
        }

        public void Trace(string message, params object[] args)
        {
            _logger.Trace(message.FormatWith(args));
        }

        public void Warn(string message, params object[] args)
        {
            _logger.Warn(message.FormatWith(args));
        }
    }
}