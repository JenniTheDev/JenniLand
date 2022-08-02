using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;

public class LogSeverityTracker
{
    public readonly List<string> IgnoredMessages = new List<string>();

    public void Register()
    {
        Application.logMessageReceived -= KeepSeverestMessage;
        Application.logMessageReceived += KeepSeverestMessage;
        // make sure the ignored messages can't kill us
        foreach (var ignoredMsg in IgnoredMessages)
        {
            LogAssert.Expect(LogType.Error, ignoredMsg);
        }
    }

    public void Reset()
    {
        strongestLogSeverity = 0;
        strongestLogType = LogType.Log;
    }

    public void AssertCleanLog(string msg = null)
    {
        var prefix = string.IsNullOrEmpty(msg) ? "" : (msg + ": ");
        Assert.That(strongestLogType, Is.EqualTo(LogType.Log), prefix + $"found severe {strongestLogType}:\n{strongestLog}");
    }

    // -------------------------------------------------- private state

    private string strongestLog;
    private int strongestLogSeverity = 0;
    private LogType strongestLogType = LogType.Log;

    // -------------------------------------------------- private logic

    private void KeepSeverestMessage(string logString, string stackTrace, LogType type)
    {
        bool isIgnored = IgnoredMessages.Any(msg => logString.Contains(msg));
        if (isIgnored)
        {
            return;
        }

        int newSeverity = ScoreSeverityOf(type);
        if (newSeverity > strongestLogSeverity)
        {
            strongestLog = logString;
            strongestLogSeverity = newSeverity;
            strongestLogType = type;
        }
    }

    /// <summary>
    ///   annoyingly the LogType enum does not have semantic ordering! so let's work out our own.
    ///   higher numbers mean more severe.
    /// </summary>
    private int ScoreSeverityOf(LogType log)
    {
        switch (log)
        {
            case LogType.Log: return 0;
            case LogType.Warning: return 1;
            case LogType.Assert: return 2;
            case LogType.Error: return 3;
            case LogType.Exception: return 4;
            default:
                Assert.Fail($"unknown log type {log}");
                return int.MaxValue;
        }
    }
}