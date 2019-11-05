using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.TestRunner;
using UnityEngine.TestTools;
using UnityTestExtensions;

[assembly: TestRunCallback(typeof(LogAssertEx.LogAssertionCallbacks))]

namespace UnityTestExtensions
{
    /// <summary>
    /// Helper class for dealing with log messages that enhances the <see cref="LogAssert"/> class.
    /// </summary>
    public static class LogAssertEx
    {
        public class LogAssertionCallbacks : ITestRunCallback
        {
            public void RunStarted(ITest testsToRun)
            {
                ignoredMessages.Clear();
            }

            public void RunFinished(ITestResult testResults)
            {
                ignoredMessages.Clear();
            }

            public void TestStarted(ITest test)
            {
                ignoredMessages.Clear();
            }

            public void TestFinished(ITestResult result)
            {
                ignoredMessages.Clear();
            }
        }

        private static readonly Dictionary<LogType, List<Regex>> ignoredMessages =
            new Dictionary<LogType, List<Regex>>();

        static LogAssertEx()
        {
            Application.logMessageReceived += OnLogReceived;
        }

        private static void OnLogReceived(string condition, string stacktrace, LogType type)
        {
            if (ignoredMessages.ContainsKey(type) && ignoredMessages[type].Any(r => r.IsMatch(condition)))
            {
                LogAssert.Expect(type, condition);
            }
        }

        /// <summary>
        /// Ignores *ANY* message of the given log type throughout the execution of the currently running test.
        /// Any number of messages that will be logged will not cause the test to fail.
        /// </summary>
        public static void IgnoreMessage(LogType logType, string message)
        {
            Add(logType, new Regex($"^{message}$"));
        }

        /// <summary>
        /// Ignores *ANY* regex message of the given log type throughout the execution of the currently running test.
        /// Any number of messages that will be logged will not cause the test to fail.
        /// </summary>
        public static void IgnoreMessage(LogType logType, Regex message)
        {
            Add(logType, message);
        }

        private static void Add(LogType logType, Regex message)
        {
            if (!ignoredMessages.ContainsKey(logType))
            {
                ignoredMessages.Add(logType, new List<Regex>());
            }

            ignoredMessages[logType].Add(message);
        }
    }
}