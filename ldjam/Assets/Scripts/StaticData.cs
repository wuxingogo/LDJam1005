using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wuxingogo.Runtime;
[CreateAssetMenu]
public class StaticData : GameManager<StaticData>
{
    
    public float normalSpeed = 7.5f;
    public float otherSpeed = 6;
    public Vector3 hintOffset = Vector3.zero;
    public RuntimeAnimatorController[] legAnimations = null;
    public float dialogDeltaTime = 3f;
    public Vector3 finishLevelZoneOffset = new Vector3(0, 0, -5);
    public RuntimeAnimatorController GetLegAnim(int index)
    {
        
            return legAnimations[index];
    }
    
}
