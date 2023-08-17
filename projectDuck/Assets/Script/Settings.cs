using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Settings : UIObject
{
    public Slider musicSlider;
    public Slider SESlider;

    public Text musicVolumeText;
    public Text SEVolumeText;

    // Start is called before the first frame update
    void Start()
    {
        float BGM_volume = DataManager.GetData<float>("float", "BGM_Volume");
        float SE_volume = DataManager.GetData<float>("float", "SE_Volume");

        float BGMmaxValue = Mathf.Max(100, BGM_volume);
        float SEmaxValue = Mathf.Max(100, SE_volume);

        musicSlider.value = Mathf.Max(BGMmaxValue);
        SESlider.value = Mathf.Max(SEmaxValue);

        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume()
    {
        if (musicVolumeText != null) musicVolumeText.text = Mathf.RoundToInt(musicSlider.value * 100).ToString();
        if (SEVolumeText != null) SEVolumeText.text = Mathf.RoundToInt(SESlider.value * 100).ToString();

        AudioManager.SetBGMVolume(musicSlider.value);
        AudioManager.SetSEVolume(SESlider.value);

        Debug.Log("SetValue");
    }
}
