using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaProfilePage : LobbyUIObject
{
    public override void OpenUI(UIManager rUIManager, LobbyUIObject rSrcUI)
    {
        base.OpenUI(rUIManager, rSrcUI);
    }
    public void BtnClose()
    {
        CloseUI();
    }
}
