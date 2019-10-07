using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class StoryCtr : MonoBehaviour
{
    public Animator dialogAnim= null;
    public int dialogCount = 0;
    public void OnNextClick()
    {
        dialogAnim.SetTrigger("continue");
        dialogCount++;
        if (dialogCount > 2)
        {
            XLogger.Log("Finish Story");
            InputManager.Instance.InputDetectionActive = true;
            gameObject.SetActive(false);
        }
    }

    public void Start()
    {
        
    }
    
}
