using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int index;
    public string name;
    public float floatData;
    public bool boolData;
    [TextArea(3,5)]
    public string intro;
    [Tooltip("Duck Image")]
    public Sprite duckImage;
}

[CreateAssetMenu(fileName = "New Data", menuName = "Create Data Asset", order = 0)]
public class DuckData : ScriptableObject
{
    public List<Data> dataList;
}
