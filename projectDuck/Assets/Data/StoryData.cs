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
        public string name;                 // �۩w�q�s��
        public string Left_name;            // ���訤��
        public Image Left_Image;
        public string Right_name;           // �k�訤��
        public Image Right_Image;

        // ������{�S��

        [TextArea(3, 5)]
        public string content;              // ��ܤ��e
    }
}


[CreateAssetMenu(fileName = "New Story Data", menuName = "Story Data", order = 3)]
public class StoryData : ScriptableObject
{
    public StoryInfo storyInfo;
}
