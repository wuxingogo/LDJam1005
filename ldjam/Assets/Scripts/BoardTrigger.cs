using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class BoardTrigger : MonoBehaviour
{
    public float ySize = 12.3f;
    public void OnTriggerEnter2D(Collider2D other)
    {
        var bounds = LevelManager.Instance.LevelBounds;
        bounds.extents = new Vector3(bounds.extents.x, ySize, bounds.extents.z);
        LevelManager.Instance.LevelBounds = bounds;
    }
}
