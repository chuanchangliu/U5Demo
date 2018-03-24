//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class DebugOption
{
    public bool readPackedCode;
    public bool readPackedData;
    public bool readPackedView;
    public bool fullFrameRate;
    public bool skipProgramUpdate;
    public bool skipResouceUpdate;
    public string externalPath;
}

public class Settings
{
    public static bool readPackedCode;
    public static bool readPackedData;
    public static bool readPackedView;
    public static bool skipProgramUpdate;
    public static bool skipResouceUpdate;

    public static string externalPath;

    public static void ParseCommandLine()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        string[] aArgs = Environment.GetCommandLineArgs();
        if (Array.IndexOf(aArgs, "-skipprogupdate") >= 0)
            skipProgramUpdate = true;
#endif
    }

    public static void InitSettings(DebugOption options)
    {
        //app相关参数设置
        Application.targetFrameRate = options.fullFrameRate ? 60 : 30;
        Time.maximumDeltaTime = 0.25f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        ScreenConfig.init();

        //开发期相关参数设置
        readPackedCode = options.readPackedCode;
        readPackedData = options.readPackedData;
        readPackedView = options.readPackedView;
        skipProgramUpdate = options.skipProgramUpdate;
        skipResouceUpdate = options.skipResouceUpdate;

        externalPath = string.IsNullOrEmpty(options.externalPath) ? Application.persistentDataPath : options.externalPath;
    }

    public static void ReviewSettings()
    {
        Debug.Log("====read packed code: " + readPackedCode.ToString());
        Debug.Log("====read packed data: " + readPackedData.ToString());
        Debug.Log("====read packed view: " + readPackedView.ToString());
        Debug.Log("====skip Program Update: " + skipProgramUpdate.ToString());
        Debug.Log("====skip Resouce Update: " + skipResouceUpdate.ToString());
        Debug.Log("====target frame rate: " + Application.targetFrameRate.ToString());
        Debug.Log("====external path : " + externalPath);
    }
}
