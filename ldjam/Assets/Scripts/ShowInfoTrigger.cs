using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wuxingogo.Runtime;
using wuxingogo.tools;

public class ShowInfoTrigger : MonoBehaviour
{
    public List<string> contents= new List<string>();
    public void OnTriggerEnter2D(Collider2D other)
    {
        this.StopAllCoroutines();
        for (int i = 0; i < contents.Count; i++)
        {
            var content = contents[i].ToUpper();
            AsynchronousFunc.Delaytime(i * StaticData.Instance.dialogDeltaTime, () =>
            {
                HintCtr.Inst.ShowContent(content, transform);
            }, this);
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HintCtr.Inst.UnShow();
    }
}
