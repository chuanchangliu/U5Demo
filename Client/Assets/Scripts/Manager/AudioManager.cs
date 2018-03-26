using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioManager : MonoSingleton<AudioManager>
{

    public void Init()
    {
        Debug.Log("====AudioManager Init====");
    }
}
