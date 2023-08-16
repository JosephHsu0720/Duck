using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitData
{
    public int id;
    public string unitName;

    public int level;
    public int ATK;
    public int DEF;
    public int HP;

    public void SetBattleUnitData(UnitInfo playerInfo)
    {
        id = playerInfo.id;
        unitName = playerInfo.name;

        level = playerInfo.level;
        ATK = playerInfo.atk;
        DEF = playerInfo.def;
        HP = playerInfo.hp;
    }
}
