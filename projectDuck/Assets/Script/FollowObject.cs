using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform followTarget;
    public float moveSpeed;

    public bool needToFollow;

    public void FollowOn()
    {
        if (needToFollow)
        {
            Vector3 dir = followTarget.position - transform.position;
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}