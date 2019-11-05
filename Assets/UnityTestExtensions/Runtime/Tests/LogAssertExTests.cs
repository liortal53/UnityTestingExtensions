using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;

namespace UnityTestExtensions
{
    [TestFixture]
    public class LogAssertExTests
    {
        [Test]
        public void IgnoreMessage_Log_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Log, "testing this");

            Debug.Log("testing this");
            Debug.Log("testing this");
        }

        [Test]
        public void IgnoreMessage_Warning_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Warning, "testing this");

            Debug.LogWarning("testing this");
            Debug.LogWarning("testing this");
        }

        [Test]
        public void IgnoreMessage_Assertion_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Assert, "testing this");

            Debug.LogAssertion("testing this");
            Debug.LogAssertion("testing this");
        }

        [Test]
        public void IgnoreMessage_Error_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Error, "testing this");

            Debug.LogError("testing this");
            Debug.LogError("testing this");
        }
        
        [Test]
        public void IgnoreMessage_LogRegex_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Log, new Regex("TEST.*"));

            Debug.Log("TESTING 1 2 3");
            Debug.Log("TESTING 1 2 3");
        }

        [Test]
        public void IgnoreMessage_WarningRegex_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Warning,  new Regex("TEST.*"));

            Debug.LogWarning("TESTING 1 2 3");
            Debug.LogWarning("TESTING 1 2 3");
        }

        [Test]
        public void IgnoreMessage_AssertionRegex_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Assert, new Regex("TEST.*"));
           
            Debug.LogAssertion("TESTING 1 2 3");
            Debug.LogAssertion("TESTING 1 2 3");
        }

        [Test]
        public void IgnoreMessage_ErrorRegex_DoesntFailTest()
        {
            // Ignore error logs with message - "test"
            LogAssertEx.IgnoreMessage(LogType.Error,  new Regex("TEST.*"));
            
            Debug.LogError("TESTING 1 2 3");
            Debug.LogError("TESTING 1 2 3");
        }
    }
}