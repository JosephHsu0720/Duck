using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("Common")]
    bool onSelect = false;
    public Image onSelectImg;
    public delegate void onClickCallBack(Image img);

    [Header("CharaProfile")]
    public Text nameText;
    public Text introText;
    public Image duckImage;
    onClickCallBack onClickCB;

    [Header("GachaPage")]
    public Text orderText;

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            SetSelectSprite(EventSystem.current.currentSelectedGameObject.Equals(gameObject));
        }
    }

    public void ShowCharaData(Data srcData, bool active, onClickCallBack onClickCallBack = null)
    {
        if (nameText != null)
        {
            nameText.text = srcData.name;
        }
        if (introText != null)
        {
            introText.text = srcData.intro;
        }
        if (duckImage != null)
        {
            duckImage.sprite = srcData.unitSprite;
        }
        onClickCB = onClickCallBack;

        gameObject.SetActive(active);
    }

    public void ShowGachaData(int order, bool active)
    {
        if (orderText.text != null)
        {
            orderText.text = order.ToString();
        }
        gameObject.SetActive(active);
    }

    public void OnClick()
    {
        onSelect = !onSelect;
        SetSelectSprite(onSelect);

        onClickCB?.Invoke(duckImage);
    }
    void SetSelectSprite(bool active)
    {
        if (onSelectImg != null)
        {
            onSelectImg.gameObject.SetActive(active);
        }
    }
}
