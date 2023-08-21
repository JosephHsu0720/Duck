using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("CharaProfile")]
    public Text nameText;
    public Text introText;
    public Image duckImage;

    [Header("GachaPage")]
    public Text orderText;

    private void Start()
    {

    }

    public void ShowCharaData(Data srcData, bool active)
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
}
