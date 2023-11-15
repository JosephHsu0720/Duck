using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    public virtual void OpenUI()
    {
        gameObject.SetActive(true);
    }
    public virtual void RefreshUI()
    {

    }
    public void ReturnUI()
    {

    }
    public void OpenOtherUI()
    {

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
