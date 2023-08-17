using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("ShowData")]
    public Text nameText;
    public Text introText;
    public Image duckImage;

    private void Start()
    {

    }

    public void Show(Data srcData, bool active)
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
            duckImage.sprite = srcData.duckImage;
        }

        gameObject.SetActive(active);
    }
}
