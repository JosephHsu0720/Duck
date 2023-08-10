using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager GetInstance()
    {
        return instance;
    }

    public Dictionary<string, LobbyUIObject> UIPrefabs = new Dictionary<string, LobbyUIObject>();

    [SerializeField]
    List<string> UIStack;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UIStack = new List<string>();
    }
    public void OpenUI(string UIName, LobbyUIObject srcUI)
    {
        if (UIPrefabs.ContainsKey(UIName)) // 有沒有 UI 資料
        {
            UIPrefabs[UIName].transform.SetAsLastSibling(); // UI 移到最下面
            UIPrefabs[UIName].OpenUI(this, srcUI);

            /*int index = UIStack.IndexOf(UIName);
            if (index == -1)
            {
                UIStack.Add(UIName);
            }*/
            return;
        }

        StartCoroutine(OpenUICoroutine(UIName, srcUI));
    }

    IEnumerator OpenUICoroutine(string UIName, LobbyUIObject srcUI)
    {
        // Open Block;

        GameObject lobbyUIPrefab = Instantiate(Resources.Load<GameObject>(UIName));
        lobbyUIPrefab.name = UIName;
        // Set Parent Root;
        RectTransform rectTransform = lobbyUIPrefab.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.localPosition = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localEulerAngles = Vector3.zero;
            rectTransform.localScale = Vector3.one;
        }

        UIPrefabs[UIName] = lobbyUIPrefab.GetComponent<LobbyUIObject>();
        UIStack.Add(UIName);

        yield return null;
        // Close Block

        OpenUI(UIName, srcUI);
    }
}
