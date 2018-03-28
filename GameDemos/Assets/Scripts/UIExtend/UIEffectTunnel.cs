using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffectTunnel : MonoBehaviour {

    public GameObject effectNode;
    private int childCount;
    private float scaleDelta = 1f;
    private float scaleMax = 2.0f;
    private float scaleMin = 0.1f;
    private List<float> scaleList = new List<float>();
    private List<Transform> transList = new List<Transform>();
    private List<UITexture> transImge = new List<UITexture>();
    private int startIndex = -1;
    private bool stop = false;

	// Use this for initialization
	void Start ()
    {
        childCount = effectNode.transform.childCount;
        Transform trans;
        for(int i= 0; i<childCount;++i)
        {
            scaleList.Add(-0.2f*i+1);
            trans = effectNode.transform.GetChild(i).gameObject.transform;
            transList.Add(trans);
            transImge.Add(trans.GetComponent<UITexture>());
        }
	}

    IEnumerator Reposition(int IdxStart)
    {
        int realIdx = 0;
        for (int i = 1; i <= childCount; ++i)
        {
            realIdx = IdxStart + i;
            if (realIdx >= childCount)
            {
                realIdx = realIdx - childCount;
            }
            transImge[realIdx].depth = i;

            yield return realIdx;
        }

        yield return null;
    }
	
	void FixedUpdate ()
    {
        for(int i=0; i<childCount;++i)
        {
            float scale = scaleList[i];
            scale += Time.deltaTime * scaleDelta;
            if (scale >= scaleMax)
            {
                scale = scaleMin;
                startIndex = i;
                transList[i].localScale = new Vector3(scale, scale, 1);
                StartCoroutine("Reposition", startIndex);
            }
            else
            {
                transList[i].localScale = new Vector3(scale, scale, 1);
            }
            scaleList[i] = scale;
            //transImge[i].color = new Color(0f,0f,0f);
        }
		
	}
}
