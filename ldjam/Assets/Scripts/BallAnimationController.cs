using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class BallAnimationController : MonoBehaviour
{
    public CanvasGroup canGroup = null;
    public Animator mAnimator = null;
    public GameObject storyAnimator = null;
    public bool isShowHint = false;
    public GameObject hintGo = null;
    public void OnPlayOpenup()
    {
        if (isShowHint == false)
        {
            isShowHint = true;
            hintGo.SetActive(true);
        }
        else
        {
            mAnimator.SetTrigger("tigger_to_start");
        }
        
    }

    private void Start()
    {
        InputManager.Instance.InputDetectionActive = false;
    }

    public void OnOpenupFinish()
    {
        XLogger.Log("On Animation Play Finish!!!");
        if (canGroup != null)
        {
            var action = canGroup.DOFade(0, 2);
            action.onComplete = () =>
            {
                canGroup.gameObject.SetActive(false);
                storyAnimator.gameObject.SetActive(true);
            };

        }
    }
}
