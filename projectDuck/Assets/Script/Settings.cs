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

    int BGM_volume;
    int SE_volume;

    // Start is called before the first frame update
    void Start()
    {
        BGM_volume = DataManager.GetData<int>("int", "BGM_Volume");
        SE_volume = DataManager.GetData<int>("int", "SE_Volume");

        musicSlider.value = (float)BGM_volume / 100;
        SESlider.value = (float)SE_volume / 100;

        SetVolume();
    }

    public void SetVolume()
    {
        // Slider
        BGM_volume = Mathf.RoundToInt(musicSlider.value * 100);
        SE_volume = Mathf.RoundToInt(SESlider.value * 100);

        // Text
        if (musicVolumeText != null) musicVolumeText.text = BGM_volume.ToString();
        if (SEVolumeText != null) SEVolumeText.text = SE_volume.ToString();

        // Output Volume
        AudioManager.SetBGMVolume(BGM_volume);
        AudioManager.SetSEVolume(SE_volume);

        //Debug.Log("SetValue");
    }
}
