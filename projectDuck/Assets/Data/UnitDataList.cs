using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int index;
    public UnitType Type;
    public string name;

    public int level;
    public int ATK;
    public int DEF;
    public int HP;

    [TextArea(3,5)]
    public string intro;
    [Tooltip("Unit Sprite")]
    public Sprite unitSprite;
}

public enum UnitType
{
    Ally,
    Enemy,
}

[CreateAssetMenu(fileName = "New Data List", menuName = "Data List", order = 0)]
public class UnitDataList : ScriptableObject
{
    public List<Data> dataList;
}
