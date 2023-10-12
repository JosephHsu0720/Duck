using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitData
{
    public int id;
    public string unitName;
    static public string unitType;  // 敵人專用

    public int level;
    public float SPD;
    public int ATK;
    public int DEF;
    public int HP;

    public void SetPlayerData(UnitInfo playerInfo)
    {
        unitName = playerInfo.name;

        level = playerInfo.level;
        ATK = playerInfo.atk;
        DEF = playerInfo.def;
        HP = playerInfo.hp;
    }

    public void SetEnemyData(List<Data> unitDataList, int index)
    {
        Data unitData = unitDataList.Find((x) => x.index == index);

        if (unitData == null)
        {
            Debug.LogError($"unit index {index} not found");
            return;
        }
        else
        {
            id = unitData.index;
            unitName = unitData.name;
            unitType = unitData.unitType.ToString();

            SPD = unitData.SPD;
            ATK = unitData.ATK;
            HP = unitData.HP;
        }
    }
}
