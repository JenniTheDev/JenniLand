using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.TestTools;

namespace UnityEditor.TestTools
{
    [TestFixtureSource(typeof(AllRequiredLevelsProvider))]
    public class SceneSmokeTests
    {
        private string levelToSmoke;
        private LogSeverityTracker logSeverityTracker = new();
        private int secondsToWait = 5;

        [Preserve]
        public SceneSmokeTests(string levelToTest)
        {
            levelToSmoke = levelToTest;
        }

        [OneTimeSetUp]
        public void LoadScene()
        {
            logSeverityTracker.Register();
            logSeverityTracker.IgnoredMessages.AddRange(new[] { "Log" });
            // logSeverityTracker.Register();
            SceneManager.LoadScene(levelToSmoke);
        }

        [Test, Order(1)]
        public void LoadsClean()
        {
            logSeverityTracker.Reset();
            logSeverityTracker.AssertCleanLog();
        }

        [UnityTest, Order(2)]
        public IEnumerator RunsClean()
        {
            logSeverityTracker.Reset();
            yield return new WaitForSeconds(secondsToWait);
            logSeverityTracker.AssertCleanLog();
        }

        [UnityTest, Order(3)]
        public IEnumerator UnloadsClean()
        {
            logSeverityTracker.Reset();
            yield return SceneManager.LoadSceneAsync("JenniMenu");
            logSeverityTracker.AssertCleanLog();
        }
    }
}