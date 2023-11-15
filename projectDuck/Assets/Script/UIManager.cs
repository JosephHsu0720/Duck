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

    public Dictionary<string, UIObject> UIPrefabs = new Dictionary<string, UIObject>();
    public Transform uiRoot;

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
    public void OpenUI(GameUI ui)
    {
        string uiName = ui.ToString();
        if (UIPrefabs.ContainsKey(uiName))
        {
            UIPrefabs[uiName].transform.SetAsLastSibling();
            UIPrefabs[uiName].OpenUI();

            return;
        }
        StartCoroutine(OpenUICoroutine(ui, uiName));
    }

    IEnumerator OpenUICoroutine(GameUI ui, string uiName)
    {
        // Open Block;

        GameObject lobbyUIPrefab = Instantiate(Resources.Load<GameObject>(uiName), uiRoot);
        lobbyUIPrefab.name = uiName;
        // Set Parent Root;
        RectTransform rectTransform = lobbyUIPrefab.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.localPosition = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localEulerAngles = Vector3.zero;
            rectTransform.localScale = Vector3.one;
        }

        UIPrefabs[uiName] = lobbyUIPrefab.GetComponent<UIObject>();
        UIStack.Add(uiName);

        yield return null;
        // Close Block

        OpenUI(ui);
    }

    public void CloseUI(GameUI ui)
    {
        string uiName = ui.ToString();
        if (UIPrefabs.ContainsKey(uiName))
        {
            UIPrefabs[uiName].CloseUI();
        }
        else
        {
            Debug.LogWarning("No uiPrefab: " + uiName + "exist.");
        }
    }
}
