using UnityEngine;
using UnityEditor;
using System.Collections;

static public class ExtendTools
{
    [MenuItem("GameObject/ExtendTools/SavePrefab", priority = 0)]
    static public void SavePrefab()
    {
        GameObject source = Selection.activeGameObject;
        string prefabName = source.name;
        Debug.Log("====prefabName: " + prefabName);

        //string prefabPath = Settings.GetAssetPath(source).ToLower();
        
        //PrefabUtility.CreatePrefab();
    }
}