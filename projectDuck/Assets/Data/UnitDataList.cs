using System.Collections;
using System.Collections.Generic;
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

    public List<string> mybullet;

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

    private void OnValidate()
    {
        //List<BulletData> bulletInfos = BulletTypeDictionary.bulletInfos;

        //string generatedTag = "public enum MyBullets{";
        //for (int i = 0; i < bulletInfos.Count; i++)
        //{
        //    generatedTag += $"{bulletInfos[i].name},";
        //}
        //generatedTag += "}";

        //string relativePath = Application.dataPath + @"/Data/";
        //string fileName = "UnitDataList.cs";
        //string tempPath = relativePath + fileName;

        //if (!Directory.Exists(relativePath))
        //{
        //    Directory.CreateDirectory(relativePath);
        //}
        //using (StreamWriter file = new StreamWriter(tempPath))
        //{
        //    file.WriteLine(generatedTag);
        //}
        //UnityEditor.AssetDatabase.ImportAsset(tempPath);
    }
}