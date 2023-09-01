using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 隨從
public class EntourageMode : FollowObject
{
    private void LateUpdate()
    {
        if (Vector2.Distance(followTarget.position, transform.position) > 0.3f)
        {
            FollowOn();
        }
    }
}
