using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Data
{
    public UnitType Type;
    public string name;
    [TextArea(3,5)]
    public string intro;
    [Tooltip("Duck Image")]
    public Sprite duckImage;
}

public enum UnitType
{
    Ally,
    Enemy,
}

[CreateAssetMenu(fileName = "New Data List", menuName = "Create Data List", order = 0)]
public class DataList : ScriptableObject
{
    public List<Data> dataList;
}
