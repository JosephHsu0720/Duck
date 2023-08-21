using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitUI : MonoBehaviour
{
    public Camera UICamera;

    [SerializeField] BattleUnitController srcUnit = null;
    [SerializeField] Transform srcUnitTransform;
    [SerializeField] RectTransform thisRectTransform;
    [SerializeField] RectTransform fieldRoot;

    public HealthBarUI hpBarUI;

    bool isSetPos = false;

    public void SetUnit(BattleUnitController targetUnit)
    {
        srcUnit = targetUnit;
        srcUnitTransform = srcUnit.transform;
        thisRectTransform = GetComponent<RectTransform>();
        fieldRoot = transform.parent.GetComponent<RectTransform>();

        SetUIPos();
    }

    void SetUIPos()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(srcUnitTransform.position);
        thisRectTransform.position = screenPos;
    }

    private void Update()
    {
        if (Camera.main && srcUnit && isSetPos)
        {
            /*Vector2 screenPos = Camera.main.WorldToScreenPoint(srcUnitTransform.position); // 敵人圖片轉螢幕座標
            RectTransformUtility.ScreenPointToLocalPointInRectangle(fieldRoot, screenPos, Camera.main, out Vector2 localPoint);
            thisRectTransform.localPosition = localPoint;*/

            Vector2 screenPos = Camera.main.WorldToScreenPoint(srcUnitTransform.position);
            thisRectTransform.position = screenPos;
        }
    }
}
