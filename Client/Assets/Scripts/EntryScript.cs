﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryScript : MonoBehaviour {
   
    public DebugOption options;

	// Use this for initialization
	void Awake()
    {
        Settings.InitSettings(options);
        Settings.ParseCommandLine();
        Settings.ReviewSettings();
	}

    private void Start()
    {
        if (Settings.showFPSMeter)
            gameObject.AddComponent<FPSMeter>();

        /*
        GameObject masterObj = GameObject.Find("GameManager");
        if (masterObj == null){
            masterObj = new GameObject("GameManager");
        }

        masterObj.AddComponent<GameMaster>();

        DestroyImmediate(gameObject);
        */

        GameMaster.Instance.Init();
    }
}
