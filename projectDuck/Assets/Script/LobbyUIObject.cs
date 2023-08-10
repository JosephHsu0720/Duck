using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIObject : MonoBehaviour
{
    UIManager uiManager;    // �I�s�� UI �� Manager
    LobbyUIObject srcUI;    // �I�s�� UI �� UI

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
