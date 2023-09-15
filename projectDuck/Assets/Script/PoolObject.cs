using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : FollowObject
{
    public class MyBullets
    {
        public List<BulletData> BulletDatas;
    }

    public event Action<GameObject> RecycleEvent;
    public string objectTag;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.45f);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        Debug.Log(collision.collider.name);
    //    }
    //}

    public void SetUp(string tag, Transform target, Action<GameObject> destroyCB)
    {
        objectTag = tag;
        followTarget = target;
        RecycleEvent = destroyCB;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BattleUnitController unitController = GetComponent<BattleUnitController>();
        if (collision.tag == "Player")
        {
            Debug.Log(collision.name);

            unitController.AddHP(-15);
        }
    }

    private void Update()
    {
        FollowOn();
        //Vector3 dir = followTarget.position - transform.position;
        //transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        // CircleCast
        //RaycastHit2D circleHit2D = Physics2D.CircleCast(transform.position, 0.45f, Vector2.zero);
        //if (circleHit2D && circleHit2D.collider.tag == "Player")
        //{
        //    Debug.Log(circleHit2D.collider.name);
        //}
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    Debug.Log(col.name);
    //    Recycle();
    //}

    public void Recycle()
    {
        RecycleEvent?.Invoke(gameObject);
    }
}
