using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoSingleton<GameMaster>
{

    public delegate void CallbackVoid();

    public CallbackVoid onDestroy = null;
    public CallbackVoid onApplicationQuit = null;


    public void Init()
    {
        Debug.Log("====GameMaster Init====");
        DontDestroyOnLoad(gameObject);
        CreateManagers();
        StartCoroutine(GameStartUp());
    }

    // Use this for initialization
    void Start (){}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        Debug.Log("====OnDestroy====");
        if (onDestroy != null)
            onDestroy();
    }

    void CreateManagers()
    {
        TrackManager.Instance.Init();
        AudioManager.Instance.Init();
        UpdateManager.Instance.Init();
    }

    IEnumerator GameStartUp()
    {
        Debug.Log("====Game Awake=====");

        foreach (var item in UpdateManager.Instance.UpdateCoroutine())
            yield return item;
    }

    void OnApplicationQuit()
    {
        Debug.Log("====OnApplicationQuit====");
        if (onApplicationQuit != null)
            onApplicationQuit();
    }
}
