using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using wuxingogo.Runtime;
using wuxingogo.tools;

public class BezierToCollider : XMonoBehaviour
{
    public enum ColliderType
    {
        PolygonCollider,
        EdgeCollider
        
    }

    public ColliderType colliderType = ColliderType.PolygonCollider;
    [X]
    public void ExportPolygon()
    {
        
        XBezierArrow bezierArrow = this.As<XBezierArrow>();

        var points = bezierArrow.GetTotalPoints().ToArray();
        var arrayPoints = new Vector2[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            arrayPoints[i] = points[i];
        }
        if (colliderType == ColliderType.PolygonCollider)
        {
            PolygonCollider2D collider = this.As<PolygonCollider2D>();
            collider.points = arrayPoints;
        }
        else
        {
            EdgeCollider2D collider = this.As<EdgeCollider2D>();
            collider.points = arrayPoints;
        }
        
    }
}
