using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public event Action<GameObject> RecycleEvent;

    public string objectTag;
    public Transform followTarget;

    [Header("Data")]
    public float moveSpeed;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void LateUpdate()
    {
        Vector3 dir = followTarget.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        Recycle();
    }

    public void Recycle()
    {
        RecycleEvent?.Invoke(gameObject);
    }
}
