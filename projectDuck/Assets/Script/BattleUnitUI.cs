using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitUI : MonoBehaviour
{
    public Camera PlayerCamera;

    [SerializeField] BattleUnitController srcUnit = null;
    [SerializeField] Transform srcUnitTransform;
    [SerializeField] RectTransform thisRectTransform;
    [SerializeField] RectTransform fieldRoot;

    public HealthBarUI hpBarUI;

    bool initial = false;

    public void SetUnit(BattleUnitController targetUnit)
    {
        srcUnit = targetUnit;
        srcUnitTransform = srcUnit.transform;
        thisRectTransform = GetComponent<RectTransform>();
        fieldRoot = transform.parent.parent.GetComponent<RectTransform>();
        PlayerCamera = Camera.main;

        SetUP();
    }

    void SetUP()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(srcUnitTransform.position); // �ĤH�Ϥ���ù��y��
        RectTransformUtility.ScreenPointToLocalPointInRectangle(fieldRoot, screenPos, PlayerCamera, out Vector2 localPoint);
        thisRectTransform.localPosition = new Vector2(localPoint.x, localPoint.y + 60f);

        initial = true;
    }

    private void LateUpdate()
    {
        if (PlayerCamera && srcUnit && initial)
        {
            Vector2 screenPos = PlayerCamera.WorldToScreenPoint(srcUnitTransform.position); // �ĤH�Ϥ���ù��y��
            RectTransformUtility.ScreenPointToLocalPointInRectangle(fieldRoot, screenPos, PlayerCamera, out Vector2 localPoint);
            thisRectTransform.localPosition = new Vector2(localPoint.x, localPoint.y + 60f);
        }
    }
}
