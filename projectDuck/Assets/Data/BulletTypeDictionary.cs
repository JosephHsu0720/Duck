using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData
{
    public string name;
    public BulletType bulletType;
    public int duration;    // 彈幕時長
    public int delayTime;   // 延遲發射
    public int interval;    // 發射間隔
    [TextArea(1, 3)]
    public string bulletInfo;

    [System.Serializable]
    public enum BulletType
    {
        line,
        circle,
        radiantion
    }
}

[CreateAssetMenu(fileName = "New Bullet Dictionary", menuName = "Bullet Dictionary", order = 5)]
public class BulletTypeDictionary : ScriptableObject
{
    public List<BulletData> bulletInfos;
}
