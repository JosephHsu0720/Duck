using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [Header("Story Data")]
    public StoryData storyData;

    [Header("Story UI")]
    public Text leftChara;
    public Text rightChara;
    public Text content;

    [Header("Parameter")]
    [Range(0, 2)][Tooltip("播放速度")] public float playSpeed;
    [Tooltip("是否跳過")] public bool skip;

    // instance
    static StoryManager instance;
    public static StoryManager GetInstance()
    {
        return instance;
    }

    // senario data
    List<StoryInfo.Senario> senarios;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        senarios = storyData.storyInfo.senarios;

        if (senarios != null) SetDialog(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            SetDialog(index);
        }
    }

    void SetDialog(int index)
    {
        if (index >= senarios.Count)
        {
            Debug.LogWarning($"out of dialog count {index} / {senarios.Count}");
        }
        else
        {
            leftChara.text = senarios[index].Left_name;
            rightChara.text = senarios[index].Right_name;
            //content.text = senarios[index].content;
            StartCoroutine(ShowDialog(senarios[index].content));
        }
    }

    /// <summary>
    /// 逐字播放文本
    /// </summary>
    IEnumerator ShowDialog(string dialog)
    {
        string showText = string.Empty;
        for (int d = 0; d < dialog.Length; d++)
        {            
            showText += dialog[d];
            content.text = showText;
            yield return new WaitForSeconds(0.1f / playSpeed);
        }
        yield return null;
    }

    WaitForSecondsRealtime WaitForFrames(int frames)
    {
        return new WaitForSecondsRealtime((float)frames / 60f);
    }
}
