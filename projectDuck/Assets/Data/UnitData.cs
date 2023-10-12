using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitInfo
{
    public string name;
    public string job;
    public int level;
    public int hp;
    public int atk;
    public int def;
    public List<string> myBullet;
}

[CreateAssetMenu(fileName = "New Unit Data", menuName = "Unit Data", order = 2)]
public class UnitData : ScriptableObject
{
    public UnitInfo playerInfo;
}
