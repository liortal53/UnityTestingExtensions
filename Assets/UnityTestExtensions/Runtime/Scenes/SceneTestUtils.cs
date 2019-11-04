using System.Collections;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace UnityTestExtensions.Scenes
{
    /// <summary>
    /// Helper class for writing tests that deal with scenes.
    /// </summary>
    public static class SceneTestUtils
    {
        private const float DEFAULT_TIMEOUT = 5f;

        /// <summary>
        /// Waits until the scene with the given name is loaded.
        /// </summary>
        public static IEnumerator WaitUntilSceneLoaded(string sceneName)
        {
            return WaitUntilSceneLoaded(sceneName, DEFAULT_TIMEOUT);
        }

        /// <summary>
        /// Waits until the scene with the given name is loaded.
        /// </summary>
        public static IEnumerator WaitUntilSceneLoaded(string sceneName, float timeoutSeconds)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                yield break;
            }

            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < DEFAULT_TIMEOUT)
            {
                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    var scene = SceneManager.GetSceneAt(i);
                    
                    if (scene.name == sceneName)
                    {
                        yield break;
                    }
                }
                
                yield return null;
            }

            var message = $"Waiting for scene '{sceneName}' to load timed out after {timeoutSeconds} seconds.";
            
            if (LogAssert.ignoreFailingMessages)
            {
                Assert.Fail(message);
            }
            else
            {
                UnityEngine.Debug.LogError(message);
            }
        }
    }
}