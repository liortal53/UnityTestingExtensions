using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;
using UnityEngine.TestTools;

namespace UnityTestExtensions
{
    /// <summary>
    /// Helper class for dealing with log messages that enhances the <see cref="LogAssert"/> class.
    /// </summary>
    public static class LogAssertEx
    {
        private class LogAssertionCallbacks : ICallbacks
        {
            public void RunStarted(ITestAdaptor testsToRun)
            {
                ignoredMessages.Clear();
            }

            public void RunFinished(ITestResultAdaptor result)
            {
                ignoredMessages.Clear();
            }

            public void TestStarted(ITestAdaptor test)
            {
                ignoredMessages.Clear();
            }

            public void TestFinished(ITestResultAdaptor result)
            {
                ignoredMessages.Clear();
            }
        }

        private static readonly Dictionary<LogType, List<Regex>> ignoredMessages =
            new Dictionary<LogType, List<Regex>>();

        private static readonly ICallbacks callbacks;

        static LogAssertEx()
        {
            callbacks = new LogAssertionCallbacks();

            // Register to receive callbacks, so the log assertion data is cleared before every test execution.
            var api = ScriptableObject.CreateInstance<TestRunnerApi>();
            api.RegisterCallbacks(callbacks);

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