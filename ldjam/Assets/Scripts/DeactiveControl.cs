using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;
using wuxingogo.Runtime;
using wuxingogo.tools;

public class DeactiveControl : MonoBehaviour
{
    public bool active = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        InputManager.Instance.InputDetectionActive = active;
        AsynchronousFunc.Delaytime(10f, EndingStory);
        var SceneCamera = Camera.main.GetComponent<CameraController>();
        SceneCamera.CameraOffset += StaticData.Instance.finishLevelZoneOffset;
    }

    public void EndingStory()
    {
        XLogger.Log("Finish Story");
        DelegateUtils.broadcast("GameEnded");
    }
}
