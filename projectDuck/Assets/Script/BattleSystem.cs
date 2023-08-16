using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleUnitController playerUnit;

    private void Start()
    {
        UnitData unitData = Player.playerData;
        //BattleUnitData battleUnitData = new BattleUnitData(unitData.playerInfo);
        //playerUnit.SetUnitData(battleUnitData);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoDamage(playerUnit, -10);
        }
    }
    public void DoDamage(BattleUnitController targetUnit, int damage)
    {
        targetUnit.AddHP(damage);
        targetUnit.UpdateUI();
    }
}
