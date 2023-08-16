using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    static StageUI instance;

    [Header("DisplayUI")]
    public Image UnitImage;
    public Image UnitPetImage;
    public Image healthBar;
    public Image healthBarBackground;
    public Text levelText;

    public HUDPanel HUDPrefab;

    static public StageUI GetInstance()
    {
        return instance;
    }
}
