using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public Image hpBarBackground;       // �զ�I��
    public Image hpBarEffectImg;        // ���⪺�S�Ĺ�
    public Image hpBar;                 // ��ڦ��

    Vector2 hpBarSprite;                // ������e

    int maxHP;
    float scaleRate;                    // ��q�M��������

    public void Show(int hpBarValue)
    {
        maxHP = Player.playerData.playerInfo.hp;

        hpBarSprite = hpBar.rectTransform.sizeDelta;
    }

    public void SetValue(int hpValue)
    {
        scaleRate = (float)hpValue / maxHP;
        hpBar.rectTransform.sizeDelta = new Vector2(Mathf.Max(0f, hpBarSprite.x * scaleRate), hpBarSprite.y);
    }
}
