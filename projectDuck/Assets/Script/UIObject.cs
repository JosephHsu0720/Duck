using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    UIManager uiManager;    // 呼叫此 UI 的 Manager
    UIObject srcUI;    // 呼叫此 UI 的 UI

    public virtual void OpenUI(UIManager rUIManager, UIObject rSrcUI)
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

    public void LoadScene(string sceneName)
    {
        if (sceneName == SceneManager.GetActiveScene().name) return;

        SceneManager.LoadScene(sceneName);
    }
}
