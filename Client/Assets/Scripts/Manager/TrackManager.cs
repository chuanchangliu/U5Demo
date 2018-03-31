using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrackManager : NormSingleton<TrackManager>
{

    public enum LogLevel
    {
        LOG = 0,
        WARNING,
        ASSERT,
        ERROR,
        MAX
    }

    public class LogData
    {
        public string Log { get; set; }
        public string Track { get; set; }
        public LogLevel Level { get; set; }
    }

    public LogLevel needOutputLv = LogLevel.LOG;
    public LogLevel needRecordLv = LogLevel.MAX;

    private Dictionary<LogType, LogLevel> _type2Level = null;

    private LogOutput _logOutput = null;

    private int _mainThreadID = -1;
    

    private TrackManager()
    {
        needOutputLv = LogLevel.LOG;
        needRecordLv = LogLevel.ERROR;
        _mainThreadID = Thread.CurrentThread.ManagedThreadId;
    }

    public void Init()
    {
        Application.logMessageReceived += LogCallback;
        Application.logMessageReceivedThreaded += LogMultiThreadCallback;

        //LogType的enum定义顺序与自定义的不同
        _type2Level = new Dictionary<LogType, LogLevel>
        {
            { LogType.Log, LogLevel.LOG },
            { LogType.Warning, LogLevel.WARNING },
            { LogType.Assert, LogLevel.ASSERT },
            { LogType.Error, LogLevel.ERROR },
            { LogType.Exception, LogLevel.ERROR },
        };

        _logOutput = new LogOutput();
        GameMaster.Instance.onDestroy += Fini;
    }

    void Fini()
    {
        Application.logMessageReceived -= LogCallback;
        Application.logMessageReceivedThreaded -= LogMultiThreadCallback;
    }

    /// <summary>
    /// 日志调用回调，主线程和其他线程都会回调这个函数，在其中根据配置输出日志
    /// </summary>
    /// <param name="log">日志</param>
    /// <param name="track">堆栈追踪</param>
    /// <param name="type">日志类型</param>
    void LogCallback(string log, string track, LogType type)
    {
        if (_mainThreadID == Thread.CurrentThread.ManagedThreadId)
            Output(log, track, type);
    }

    void LogMultiThreadCallback(string log, string track, LogType type)
    {
        if (_mainThreadID != Thread.CurrentThread.ManagedThreadId)
            Output(log, track, type);
    }

    void Output(string log, string track, LogType type)
    {
        LogLevel level = _type2Level[type];
        LogData logData = new LogData
        {
            Log = log,
            Track = track,
            Level = level,
        };
 
        _logOutput.Log(logData);
    }
}
