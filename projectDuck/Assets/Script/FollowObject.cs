using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform followTarget;

    [SerializeField] float moveSpeed;

    public void FollowOn()
    {
        Vector3 dir = followTarget.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }
}