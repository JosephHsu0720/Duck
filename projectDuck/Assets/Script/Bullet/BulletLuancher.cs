using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLuancher : MonoBehaviour
{
    static string bulletName;
    static BulletData.BulletType bulletType;
    static int duration;
    static int delayTime;
    static int interval;
    // static string bulletInfo;

    public void Initialize(BulletData bulletData)
    {
        bulletName = bulletData.name;
        bulletType = bulletData.bulletType;
        duration = bulletData.duration;
        delayTime = bulletData.delayTime;
        interval = bulletData.interval;
    }

    public IEnumerator Launch()
    {
        ObjectPoolManager.instance.Spawn(bulletName);
        yield return new WaitForSeconds(interval);
        StartCoroutine(Launch());
    }
}
