using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T>: MonoBehaviour where T : MonoSingleton <T>{

    public static T _instance;
    private static object _lock = new object();

    public static T Instance
    {
        get {
            lock(_lock)
            {
                if(_instance == null)
                {
                    string objectName = typeof(T).Name;

                    _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] " + objectName + " is more than one! please check and fix it.");
                        return _instance;
                    }
                    
                    if(_instance == null)
                    {
                        GameObject singleton = GameObject.Find(objectName);
                        if (singleton == null)
                            singleton = new GameObject(objectName);
                        _instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }
                }

                return _instance;
            }
        }
    }

    protected virtual void OnDestroy()
    {
        _instance = null;
    }
}
