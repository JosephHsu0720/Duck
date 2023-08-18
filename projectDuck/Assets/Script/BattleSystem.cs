using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleUnitController playerUnit;
    public ObjectPoolManager objectPool;

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
        do
        {
            GameObject testObj = objectPool.Spawn("poolObj");
            testObj.transform.localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), playerUnit.gameObject.transform.localPosition.z);
            yield return new WaitForSeconds(objectPool.spawnTime);
        } while (true);
    }

    public void DoDamage(BattleUnitController targetUnit, int damage)
    {
        targetUnit.AddHP(damage);
        targetUnit.UpdateUI();
    }
}
