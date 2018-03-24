using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryScript : MonoBehaviour {
   
    public DebugOption options;

	// Use this for initialization
	void Start ()
    {
        Settings.InitSettings(options);
        Settings.ParseCommandLine();
        Settings.ReviewSettings();
	}
}
