using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo
{
    public string name;
    public int ID;
    public ItemType itemType;
    public int amount;
    public string info;

    [System.Serializable]
    public enum ItemType
    {
        attack,
        defence,
        recover,
        support
    }
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data List", order = 4)]
public class ItemData : ScriptableObject
{
    public List<ItemInfo> itemList;
}
