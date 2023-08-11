using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIObject : MonoBehaviour
{
    UIManager uiManager;    // 呼叫此 UI 的 Manager
    LobbyUIObject srcUI;    // 呼叫此 UI 的 UI

    public virtual void OpenUI(UIManager rUIManager, LobbyUIObject rSrcUI)
    {
        uiManager = rUIManager;
        srcUI = rSrcUI;

        gameObject.SetActive(true);
    }
    public virtual void RefreshUI()
    {

    }
    public void ReturnUI()
    {

    }
    public void OpenOtherUI(string uiName)
    {
        uiManager = UIManager.GetInstance();
        uiManager.OpenUI(uiName, this);
    }
    public void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
