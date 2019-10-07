using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using wuxingogo.Runtime;
using wuxingogo.tools;

public class HintCtr : SingletonC<HintCtr>
{
    public Text label = null;
    public GameObject container = null;
    public Transform target = null;
    private bool isShowing = false;
    [X]
    public void ShowContent(string content, Transform transform)
    {
        label.text = content;
        target = transform;
        isShowing = true;
        SyncPos();
        container.SetActive(true);

        
    }

    public void UnShow()
    {
        container.SetActive(false);
        isShowing = false;
    }

    public void SyncPos()
    {
        var targetPos = target.position;
        
        var screenPoint = Camera.main.WorldToScreenPoint(targetPos);
        container.transform.position = screenPoint + StaticData.Instance.hintOffset;
    }
    private void FixedUpdate()
    {
        if (isShowing)
        {
            SyncPos();
        }

    }
}
