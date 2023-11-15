using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSystem : UIObject
{
    public void OpenSettings()
    {
        UIManager.GetInstance().OpenUI(GameUI.Settings);
    }
}
