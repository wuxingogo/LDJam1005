using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimationController : MonoBehaviour
{
    public Animator mAnimator = null;
    public void OnPlayOpenup()
    {
        mAnimator.SetTrigger("tigger_to_start");
    }

    public void OnOpenupFinish()
    {
        XLogger.Log("On Animation Play Finish!!!");
    }
}
