using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LobbyMode : MonoBehaviour
{
    public Text numberText;

    public Toggle testToggle;
    public Text toggleText;

    public Image imagePrefab;
    public Transform imagesRoot;
    [SerializeField] List<Image> imageList = new List<Image>();

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        string _numberText = PlayerData.GetData<string>("string", "numberText");
        if (string.IsNullOrEmpty(_numberText))
        {
            Debug.LogWarning("no saved string exists");
        }
        else
        {
            if (numberText != null)
            {
                numberText.text = _numberText;
            }
            else
            {
                Debug.LogWarning("no numberText exists");
            }
        }

        int imageCount = PlayerData.GetData<int>("int", "imageObject");
        if (imageCount != 0)
        {
            for (int i = 0; i < imageCount; i++)
            {
                CreateImage();
            }
        }
        else
        {
            Debug.LogWarning("no imageObject data exists");
        }

        if (testToggle != null)
        {
            bool _testToggle = PlayerData.GetData<bool>("bool", "testToggle");

            testToggle.isOn = _testToggle;
            SetToggleText();
        }        
    }

    public void Add()
    {
        if (numberText != null)
        {
            int.TryParse(numberText.text, out int n);
            n++;
            numberText.text = n.ToString();
        }
        else
        {
            Debug.LogWarning("no numberText exists");
        }
    }

    public void Save()
    {
        //PlayerPrefs.SetString("SavedString", numberText.text);
        PlayerData.SaveData("string", "numberText", numberText.text);
        PlayerData.SaveData("bool", "testToggle", testToggle.isOn);
        PlayerData.SaveData("int", "imageObject", imageList.Count);

        Debug.Log($"playerDataSaved: {numberText.text}");
        Debug.Log($"playerDataSaved: {testToggle.isOn}");
        Debug.Log($"playerDataSaved: {imageList.Count} imageObjects");
    }

    public void Clear()
    {
        if (numberText != null)
        {
            int.TryParse(numberText.text, out int n);
            n = 0;
            numberText.text = n.ToString();
        }
        else
        {
            Debug.LogWarning("no numberText exists");
        }
    }

    public void SetToggleText()
    {
        toggleText.text = testToggle.isOn.ToString();
    }

    public void CreateImage()
    {
        Image img = Instantiate(imagePrefab, imagesRoot);
        img.gameObject.SetActive(true);
        imageList.Add(img);
    }

    public void DeleteImage()
    {
        if (imageList.Count > 0)
        {
            Destroy(imageList[imageList.Count - 1].gameObject);
            imageList.RemoveAt(imageList.Count - 1);
        }
        else
        {
            Debug.LogWarning("no imageObject exists");
        }
    }
}
