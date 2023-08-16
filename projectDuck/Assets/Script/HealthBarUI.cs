using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class HealthBarUI : MonoBehaviour
{
    public Image hpBarBackground;       // 白色背景
    public Image hpBarEffectImg;        // 粉色的特效圖
    public Image hpBar;                 // 實際血條

    Vector2 hpBarSprite;                // 血條長寬

    int maxHP;
    float scaleRate;                    // 血量和血條的比例

    public void Show(int hpBarValue)
    {
        maxHP = Player.playerData.playerInfo.hp;

        hpBarSprite = hpBar.rectTransform.sizeDelta;
    }

    public void SetValue(int hpValue)
    {
        scaleRate = (float)hpValue / maxHP;
        hpBar.rectTransform.sizeDelta = new Vector2(Mathf.Max(0f, hpBarSprite.x * scaleRate), hpBarSprite.y);

        if (hpValue > 0)
        {
            StartCoroutine("SetHPAnimation");
        }
    }

    IEnumerator SetHPAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        hpBarEffectImg.rectTransform.DOSizeDelta(hpBar.rectTransform.sizeDelta, 1f, true);
    }
}
