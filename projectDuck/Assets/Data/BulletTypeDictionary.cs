using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletData
{
    public string name;
    public BulletType bulletType;
    public int duration;    // �u���ɪ�
    public int delayTime;   // ����o�g
    public int interval;    // �o�g���j
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
