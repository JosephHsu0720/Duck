using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum TabPageType
{
    NONE = -1,
    Duck,
    Skill
}

public class TabPage : MonoBehaviour
{
    public TabPageType type;
    public Button tabButton;
    public Transform objRoot;
    public GameObject objPrefab;

    public delegate void tabClickCallBack(TabPageType type);
    tabClickCallBack onSelectCB;

    public void SetTabButtonCB(tabClickCallBack cb = null)
    {
        onSelectCB = cb;
    }

    public virtual void OpenTab()
    {
        gameObject.SetActive(true);
    }
    public void CloseTab()
    {
        gameObject.SetActive(false);
    }
    public void SetActiveTabButton()
    {
        if (tabButton == null)
        {
            Debug.LogWarning("No Tab Button Exist");
        }
        tabButton.Select();
    }
    public void OnClick()
    {
        onSelectCB?.Invoke(type);
    }
}
