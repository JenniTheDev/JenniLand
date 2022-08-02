using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.TestTools;

[TestFixtureSource(typeof(AllRequiredLevelsProvider))]
public class SceneSmokeTests
{
    private string levelToSmoke;
    private LogSeverityTracker logSeverityTracker;

    [Preserve]
    public SceneSmokeTests(string levelToTest)
    {
        levelToSmoke = levelToTest;
    }

    [OneTimeSetUp]
    public void LoadScene()
    {
        logSeverityTracker.IgnoredMessages.AddRange(new[] { "Log", "Warning" });
        logSeverityTracker.Register();
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
        yield return new WaitForSeconds(5);
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