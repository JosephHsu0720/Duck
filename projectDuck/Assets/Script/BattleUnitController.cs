using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitController : MonoBehaviour
{
    BattleUnitData unitData;
    public HealthBarUI HealthBarUI;

    public void SetUnitData(BattleUnitData rUnitData)
    {
        unitData = rUnitData;

        HealthBarUI.Show(unitData.HP);
    }

    public void AddHP(int value)
    {
        string originHP = unitData.HP.ToString();

        unitData.HP += value;
        if (unitData.HP < 0)
        {
            Debug.Log("Dead");
            unitData.HP = 0;
        }

        Debug.Log($"{originHP} -> {unitData.HP}");
    }

    public void UpdateUI()
    {
        HealthBarUI.SetValue(unitData.HP);
    }
}
