using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioManager : NormSingleton<AudioManager>
{
    private AudioManager()
    {
        Debug.Log("====private AudioManager()====");
    }

    public void Init()
    {
        Debug.Log("====AudioManager Init====");
    }
}
