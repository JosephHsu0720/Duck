using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitController : MonoBehaviour
{
    BattleUnitData unitData;
    public BattleUnitUI battleUnitUI;
    public HealthBarUI hpBarUI;

    public void SetUnitData(BattleUnitData rUnitData)
    {
        unitData = rUnitData;

        hpBarUI.Show(unitData.HP);

        UpdateUI();
    }

    public void SetBattleUnitUI(BattleUnitUI srcUI)
    {
        battleUnitUI = srcUI;
        battleUnitUI.SetUnit(this);
        hpBarUI = srcUI.hpBarUI;
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
        hpBarUI.SetValue(unitData.HP);
    }
}
