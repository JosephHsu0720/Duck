using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaProfilePage : UIObject
{
    public List<TabPage> tabPageList;
    public TabPageType nowSelectTab;

    public override void OpenUI()
    {
        foreach (TabPage tb in tabPageList)
        {
            tb.SetTabButtonCB(SelectTab);
        }

        SelectTab(nowSelectTab);
        base.OpenUI();
    }

    public void BtnClose()
    {
        CloseUI();
    }

    public void SelectTab(TabPageType type)
    {
        if (type == TabPageType.NONE)
        {
            tabPageList[0].OpenTab();
            nowSelectTab = TabPageType.Duck;
            return;
        }
        else if (nowSelectTab == type)
        {
            return;
        }
        tabPageList[(int)nowSelectTab].CloseTab();
        tabPageList[(int)type].OpenTab();
        nowSelectTab = type;
    }
}