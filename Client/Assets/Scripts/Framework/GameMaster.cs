using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        CreateManagers();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateManagers()
    {
        AudioManager.Instance.Init();
    }

    IEnumerator GameStartUp()
    {
        Debug.Log("====Game Awake=====");
        yield break;
    }
}
