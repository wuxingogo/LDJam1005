using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;
using wuxingogo.Runtime;

public class NewAbilityTrigger : XMonoBehaviour
{
    [X]
    protected bool isFinish = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isFinish == false)
        {
            isFinish = true;
            DelegateUtils.broadcast("OnNewAbility" );
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //gameObject.SetActive(false);
    }
}
