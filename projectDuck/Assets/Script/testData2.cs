using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data2
{
    public int Int;
    public string String;
    public float Float;
    public bool Bool;
}

[CreateAssetMenu(fileName = "New Data", menuName = "Create Data Asset2", order = 2)]
public class testData2 : ScriptableObject
{
    public List<Data2> data2List; 
}
