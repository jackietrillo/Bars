using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Bars.Core.Logging;
using System.IO;

namespace Bars.Tests
{
    [TestClass]
    public class LoggerTests
    {
        private static ILogger _logger;

        private static string s_loggerName = "LoggerTests";

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _logger = new Logger(s_loggerName);
        }

        [TestMethod]
        public void Info_WhenInfoLogged_ShouldLogInfo()
        {
            var expectedGuid = Guid.NewGuid();
            _logger.Info("guid: {0}", expectedGuid);
            AssertLatestLogEntryEqualsExpectedLogEntry(String.Format("INFO|{0}|guid: {1}", s_loggerName, expectedGuid));
        }

        [TestMethod]
        public void Warn_WhenWarnLogged_ShouldLogWarn()
        {
            var expectedGuid = Guid.NewGuid();
            _logger.Warn("guid: {0}", expectedGuid);
            AssertLatestLogEntryEqualsExpectedLogEntry(String.Format("WARN|{0}|guid: {1}", s_loggerName, expectedGuid));
        }

        [TestMethod]
        public void Error_WhenErrorLogged_ShouldLogError()
        {
            var expectedGuid = Guid.NewGuid();
            _logger.Error("guid: {0}", expectedGuid);
            AssertLatestLogEntryEqualsExpectedLogEntry(String.Format("ERROR|{0}|guid: {1}", s_loggerName, expectedGuid));
        }

        [TestMethod]
        public void Error_WhenErrorWithExceptionLogged_ShouldLogErrorWithException()
        {
            var ex = new DivideByZeroException();
            var expectedGuid = Guid.NewGuid();
            _logger.Error(ex, "guid: {0}", expectedGuid);
            AssertLatestLogEntryEqualsExpectedLogEntry(String.Format("ERROR|{0}|guid: {1}", s_loggerName, expectedGuid));
        }

        [TestMethod]
        public void Fatal_WhenFatalLogged_ShouldLogFatal()
        {
            var expectedGuid = Guid.NewGuid();
            _logger.Fatal("guid: {0}", expectedGuid);
            AssertLatestLogEntryEqualsExpectedLogEntry(String.Format("FATAL|{0}|guid: {1}", s_loggerName, expectedGuid));
        }

        private void AssertLatestLogEntryEqualsExpectedLogEntry(string expected)
        {
            var log = File.ReadAllLines("Bars.log");
            var actual = log[log.Length - 1];
            const int startIndex = 25; // log entry date is 25 characters
            actual = actual.Substring(startIndex); 
            Assert.AreEqual(expected, actual);
        }
    }
}

