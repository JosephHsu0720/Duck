using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPage : UIObject
{
    public GameObject gachaPrefab;
    public Transform gachaListRoot;

    List<ItemObject> gachaList = new List<ItemObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnGacha_1()
    {
        Gacha(1);
    }

    public void BtnGacha_10()
    {
        Gacha(10);
    }

    void Gacha(int amount)
    {
        List<ItemObject> oldObjs = gachaList;                   // 複製一份資料
        if (oldObjs.Count > amount)
        {
            for (int i = 0; i < oldObjs.Count; i++)
            {
                if (i >= amount)
                {
                    Destroy(oldObjs[i].gameObject);             // 刪除多餘資料
                }
            }
        }
        gachaList = new List<ItemObject>();                     // 清空舊資料

        for (int i = 0; i < amount; i++)
        {
            int newOrder = Random.Range(0, 100);

            GameObject gachaObj;
            if (i < oldObjs.Count)                              // 如果先前有過這筆資料
            {
                gachaObj = oldObjs[i].gameObject;
            }
            else
            {
                gachaObj = Instantiate(gachaPrefab, gachaListRoot);
                // TODO: gachaObj Add clickListener += (function);
                gachaObj.transform.localPosition = Vector3.zero;
                gachaObj.transform.localScale = Vector3.one;
            }
            gachaObj.GetComponent<ItemObject>().ShowGachaData(newOrder, true);
            gachaList.Add(gachaObj.GetComponent<ItemObject>());
        }
    }
}