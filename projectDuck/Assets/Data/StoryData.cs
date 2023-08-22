using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class StoryInfo
{
    public string chapter;
    public string episode;
    public List<Senario> senarios;

    [System.Serializable]
    public class Senario
    {
        public string name;                 // 自定義編號
        public string Left_name;            // 左方角色
        public Image Left_Image;
        public string Right_name;           // 右方角色
        public Image Right_Image;

        // 情緒表現特效

        [TextArea(3, 5)]
        public string content;              // 對話內容
    }
}


[CreateAssetMenu(fileName = "New Story Data", menuName = "Story Data", order = 3)]
public class StoryData : ScriptableObject
{
    public StoryInfo storyInfo;
}
