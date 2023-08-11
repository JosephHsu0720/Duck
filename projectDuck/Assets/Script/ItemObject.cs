using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("ShowData")]
    public Text nameText;
    public Text introText;
    public Image skinImage;

    private void Start()
    {
        /*if (testData != null)
        {
            Show(testData);
        }*/
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
        if (skinImage != null)
        {
            skinImage.color = srcData.color;
        }

        gameObject.SetActive(active);
    }
}
