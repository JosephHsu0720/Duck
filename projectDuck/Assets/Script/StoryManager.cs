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
    int storyIndex = 0;
    public State storyState;

    public enum State
    {
        unPlay,
        Playing,
        Played,
        Auto
    }

    // Start is called before the first frame update
    void Start()
    {
        senarios = storyData.storyInfo.senarios;
        storyState = State.unPlay;
        // if (senarios != null) SetDialog(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SetDialog(storyIndex);
        }
        if (skip && storyState != State.Auto)
        {
            StartCoroutine(AutoShowDialog(storyIndex));
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
            switch (storyState)
            {
                case State.Played:          // 顯示完畢
                    {
                        storyIndex++;
                        storyState = State.unPlay;
                        SetDialog(storyIndex);
                        break;
                    }
                case State.Playing:         // 逐字顯示中
                    {
                        StopAllCoroutines();

                        string showText = senarios[index].content;
                        content.text = showText;
                        storyState = State.Played;
                        break;
                    }
                case State.unPlay:          // 尚未顯示
                    {
                        leftChara.text = senarios[index].Left_name;
                        rightChara.text = senarios[index].Right_name;
                        storyState = State.Playing;
                        StartCoroutine(ShowDialog(senarios[index].content));
                        break;
                    }
                case  State.Auto:           // 自動顯示
                    {
                        string showText = senarios[index].content;
                        content.text = showText;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
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
        storyState = State.Played;
        yield return null;
    }

    IEnumerator AutoShowDialog(int index) // 以當時進度的編號開始
    {
        storyState = State.Auto;
        for (; index < senarios.Count; index++)
        {
            SetDialog(index);
            yield return new WaitForSeconds(0.5f);
        }
        skip = false;
        Debug.Log("Dialog End");
        yield return null;
    }

    WaitForSecondsRealtime WaitForFrames(int frames)
    {
        return new WaitForSecondsRealtime((float)frames / 60f);
    }
}
