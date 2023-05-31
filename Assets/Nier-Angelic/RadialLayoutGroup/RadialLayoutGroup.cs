using System;
using UnityEngine;
using UnityEngine.UI;

public class RadialLayoutGroup :MonoBehaviour {
    public float Distance;
    [Range(0f,360f)]
    public float MinAngle, MaxAngle, StartAngle;

    private void Update()
    {
        CalculateRadial();
    }

    protected void OnEnable()
    { 
        CalculateRadial();
    }
    
#if UNITY_EDITOR
    protected void OnValidate()
    {
        CalculateRadial();
    }
#endif
    void CalculateRadial()
    {
        if (transform.childCount == 0)
            return;
        float fOffsetAngle = ((MaxAngle - MinAngle)) / (transform.childCount);
        
        float fAngle = StartAngle;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child != null)
            {
                Vector3 vPos = new Vector3(Mathf.Cos(fAngle * Mathf.Deg2Rad), Mathf.Sin(fAngle * Mathf.Deg2Rad), 0);
                child.localPosition = vPos * Distance;
                //Force objects to be center aligned, this can be changed however I'd suggest you keep all of the objects with the same anchor points.
                //child.anchorMin = child.anchorMax = child.pivot = new Vector2(0.5f, 0.5f);
                fAngle += fOffsetAngle;
            }
        }

    }
}