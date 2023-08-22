using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [Header("BattleUnitUI")]
    public Transform UIRoot;
    public Transform unitRoot;

    [Header("BattleUnitObj")]
    //public GameObject BattleUnitPrefab;
    public GameObject BattleUnitUIPrefab;

    public BattleUnitController playerUnit;
    public ObjectPoolManager objectPool;

    public int maxObjAmount;

    private void Start()
    {
        UnitData unitData = Player.playerData;
        //BattleUnitData battleUnitData = new BattleUnitData(unitData.playerInfo);
        //playerUnit.SetUnitData(battleUnitData);

        StartCoroutine(testSpawn());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoDamage(playerUnit, -10);
        }
    }

    IEnumerator testSpawn()
    {
        int n = 0;
        do
        {
            // 敵人資料
            UnitDataList BUDList = AssetDatabase.LoadAssetAtPath<UnitDataList>("Assets/Data/EnemyData.asset");  // 資料庫
            BattleUnitData battleUnitData = new BattleUnitData();
            battleUnitData.SetEnemyData(BUDList.dataList, 3001);                                                // 找對應資料

            // 產生角色 unit
            // GameObject BattleUnitPrefab = Resources.Load<GameObject>("BattleUnit");
            // GameObject unitObj = Instantiate(BattleUnitPrefab, unitRoot);
            GameObject testObj = objectPool.Spawn("poolObj");
            testObj.name = battleUnitData.unitName;
            testObj.transform.parent = unitRoot;
            BattleUnitController unitController = testObj.GetComponent<BattleUnitController>();
            testObj.transform.localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), playerUnit.gameObject.transform.localPosition.z);

            // 產生角色 UI 血條
            GameObject BattleUnitUIPrefab = Resources.Load<GameObject>("BattleUnitUI");
            GameObject uiObj = Instantiate(BattleUnitUIPrefab, UIRoot);
            uiObj.name = $"{battleUnitData.unitName}_BattleUnitUI";
            unitController.SetBattleUnitUI(uiObj.GetComponent<BattleUnitUI>());

            unitController.SetUnitData(battleUnitData);                                                         // 設定資料
            n++;

            yield return new WaitForSeconds(objectPool.spawnTime);
        } while (n < maxObjAmount);
    }

    public void DoDamage(BattleUnitController targetUnit, int damage)
    {
        targetUnit.AddHP(damage);
        targetUnit.UpdateUI();
    }
}
