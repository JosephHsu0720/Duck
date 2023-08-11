using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharaProfilePage : LobbyUIObject
{
    DuckData duckData; // ��Ʈw
    List<ItemObject> currentDuckList = new List<ItemObject>(); // �ڦ������

    public Transform duckRoot;
    public GameObject duckPrefab;

    public override void OpenUI(UIManager rUIManager, LobbyUIObject rSrcUI)
    {
        base.OpenUI(rUIManager, rSrcUI);

        duckData = AssetDatabase.LoadAssetAtPath<DuckData>("Assets/Data/DuckData.asset");
        //Debug.Log(duckData.name);
        SetUp(duckData);
    }

    void SetUp(DuckData duckData)
    {
        List<Data> duckDatabase = duckData.dataList;    // �ƻs�@�����

        List<ItemObject> oldObjs = currentDuckList;
        if (oldObjs.Count > duckDatabase.Count)         // �R���h�l���
        {
            for (int d = 0; d < oldObjs.Count; d++)
            {
                if (d >= duckDatabase.Count)
                {
                    Destroy(oldObjs[d].gameObject);
                }
            }
        }
        currentDuckList = new List<ItemObject>();

        for (int d = 0; d < duckDatabase.Count; d++)
        {
            GameObject newDuck;
            if (d < oldObjs.Count) // �p�G���e���L�o�����
            {
                newDuck = oldObjs[d].gameObject;
            }
            else
            {
                newDuck = Instantiate(duckPrefab, duckRoot);
                // TODO: newDuck Add clickListener += (function);
                newDuck.transform.localPosition = Vector3.zero;
                newDuck.transform.localScale = Vector3.one;
            }

            newDuck.GetComponent<ItemObject>().Show(duckDatabase[d], true);
            currentDuckList.Add(newDuck.GetComponent<ItemObject>());
        }
    }

    public void BtnClose()
    {
        CloseUI();
    }
}
