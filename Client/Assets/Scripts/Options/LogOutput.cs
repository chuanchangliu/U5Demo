using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System;
using UnityEngine;

public class LogOutput
{

#if UNITY_EDITOR
    string _persistentPath = Application.dataPath + "/../PersistentPath";
#elif UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    string _persistentPath = Application.dataPath + "/PersistentPath";
#else
    string _persistentPath = Application.persistentDataPath;
#endif

    private readonly object _lockObj;
    private bool _isRunning = false;
    private Thread _logThread = null;
    private StreamWriter _logWriter = null;

    private Queue<TrackManager.LogData> _writingQueue = null;
    private Queue<TrackManager.LogData> _waitingQueue = null;

    public LogOutput()
    {
        _lockObj = new object();

        GameMaster.Instance.onApplicationQuit += Fini;

        _writingQueue = new Queue<TrackManager.LogData>();
        _waitingQueue = new Queue<TrackManager.LogData>();

        System.DateTime now = System.DateTime.Now;
        string logName = string.Format("Q{0}{1}{2}{3}{4}{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
        string logPath = string.Format("{0}/Log/{1}.txt", _persistentPath, logName);
        if (File.Exists(logPath)) File.Delete(logPath);

        string logFold = Path.GetDirectoryName(logPath);
        if (!Directory.Exists(logFold))
            Directory.CreateDirectory(logFold);

        _logWriter = new StreamWriter(logPath);
        _logWriter.AutoFlush = true;

        _isRunning = true;
        _logThread = new Thread(new ThreadStart(OutputLog));
        _logThread.Start();
    }

    //输出log信息(暂时输出到文件,可添加输出至屏幕显示
    void OutputLog()
    {
        while(_isRunning)
        {
            if(_writingQueue.Count == 0)
            {
                Debug.Log("====try lock");
                lock(_lockObj)
                {
                    while(_waitingQueue.Count == 0)
                    {
                        Debug.Log("====no waitingQueue====");
                        Monitor.Wait(_lockObj);
                    }

                    Queue<TrackManager.LogData> tmpQueue = _writingQueue;
                    _writingQueue = _waitingQueue;
                    _waitingQueue = tmpQueue;
                }
            }
            else
            {
                while(this._writingQueue.Count > 0)
                {
                    TrackManager.LogData log = _writingQueue.Dequeue();
                    if(log.Level == TrackManager.LogLevel.ERROR)
                    {
                        _logWriter.WriteLine("=============Error Track============");
                        _logWriter.WriteLine(log.Log);
                        _logWriter.WriteLine(log.Track);
                        _logWriter.WriteLine("====================================");
                    }
                    else
                    {
                        _logWriter.WriteLine(log.Log);
                    }
                }
            }
        }
    }

    public void Log(TrackManager.LogData logData)
    {
        lock(_lockObj)
        {
            _waitingQueue.Enqueue(logData);
            Monitor.Pulse(_lockObj);
        }
    }

    public void Fini()
    {
        Debug.Log("====LogOutput Fini====");
        _isRunning = false;
        _logWriter.Close();
    }

}
