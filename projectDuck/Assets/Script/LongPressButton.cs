using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UGUIExtension {
    [System.Serializable]
    public class HoldEventParameter
    {
        public float requiredHoldTime;
        public UnityEvent onHold;
        public float holdEventInterval;
    }

    public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        private bool pointerDown = false;
        private float pointerDownTimer = 0f;

        [SerializeField]
        private List<HoldEventParameter> holdEventParameters;

        public UnityEvent onPointerUp;
        public UnityEvent onPointerDown;

        int currentHoldEventIndex;
        int nextHoldEventIndex;

        public void OnPointerDown(PointerEventData eventData)
        {
            pointerDown = true;
            pointerDownTimer = Time.time;
            if (holdEventParameters != null && holdEventParameters.Count > 0)
            {
                nextHoldEventIndex = 0;
            }
            if (onPointerDown != null)
            {
                onPointerDown.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Reset();
            if (onPointerUp != null)
            {
                onPointerUp.Invoke();
            }
            CancelInvoke("OnHold");
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            Reset();
            CancelInvoke("OnHold");
        }
        void OnHold()
        {
            CancelInvoke("OnHold");

            if (currentHoldEventIndex < 0 || currentHoldEventIndex >= holdEventParameters.Count) return;
            holdEventParameters[currentHoldEventIndex].onHold?.Invoke();
            if (holdEventParameters[currentHoldEventIndex].holdEventInterval > 0f)
            {
                Invoke("OnHold", holdEventParameters[currentHoldEventIndex].holdEventInterval);
            }
        }
        void Update()
        {
            if (pointerDown && nextHoldEventIndex > -1 && nextHoldEventIndex < holdEventParameters.Count)
            {
                if (Time.time >= pointerDownTimer + holdEventParameters[nextHoldEventIndex].requiredHoldTime)
                {
                    currentHoldEventIndex = nextHoldEventIndex;
                    nextHoldEventIndex = currentHoldEventIndex + 1;
                    OnHold();
                }
            }
        }
        
        void Reset()
        {
            pointerDown = false;
            pointerDownTimer = 0f;
        }


    }
}
