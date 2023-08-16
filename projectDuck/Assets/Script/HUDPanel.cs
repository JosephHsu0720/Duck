using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDPanel : MonoBehaviour
{
    public GameObject followTarget;

    [Header("DisplayUI")]
    public Image UnitImage;
    public Image UnitPetImage;
    public Image healthBar;
    public Image healthBarBackground;
    public Text levelText;

    static public HUDPanel CreateUnitHUD()
    {
        if (StageUI.GetInstance().HUDPrefab == null)
            return null;

        HUDPanel HUD = Instantiate(StageUI.GetInstance().HUDPrefab) as HUDPanel;
        if (HUD != null)
        {

        }
        return HUD;
    }
}
