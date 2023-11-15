using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class DuckTab : TabPage
{
    UnitDataList duckData; // 資料庫
    List<ItemObject> currentDuckList = new List<ItemObject>(); // 我有的資料
    bool isInitial = false;

    public Image petImage;

    public void InitializeData()
    {
        duckData = AssetDatabase.LoadAssetAtPath<UnitDataList>("Assets/Data/DuckData.asset");

        List<Data> duckDatabase = duckData.dataList;    // 複製一份資料

        List<ItemObject> oldObjs = currentDuckList;
        if (oldObjs.Count > duckDatabase.Count)         // 刪除多餘資料
        {
            for (int d = 0; d < oldObjs.Count; d++)
            {
                if (d >= duckDatabase.Count)
                {
                    Destroy(oldObjs[d].gameObject);
                }
            }
        }
        currentDuckList = new List<ItemObject>();       // 清空舊資料

        for (int d = 0; d < duckDatabase.Count; d++)
        {
            GameObject newDuck;
            if (d < oldObjs.Count)                      // 如果先前有過這筆資料
            {
                newDuck = oldObjs[d].gameObject;
            }
            else
            {
                newDuck = Instantiate(objPrefab, objRoot);
                newDuck.transform.localPosition = Vector3.zero;
                newDuck.transform.localScale = Vector3.one;
            }

            newDuck.GetComponent<ItemObject>().ShowCharaData(duckDatabase[d], true, ChangeDuckSprite);
            currentDuckList.Add(newDuck.GetComponent<ItemObject>());
        }
    }

    public override void OpenTab()
    {
        if (isInitial == false)
        {
            InitializeData();
            isInitial = true;
            SetActiveTabButton();
        }
        base.OpenTab();
    }

    void ChangeDuckSprite(Image srcImg)
    {
        if (petImage != null)
        {
            petImage.sprite = srcImg.sprite;
        }
    }
}
