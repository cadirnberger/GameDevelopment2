using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

namespace FGUIStarter
{
    /// <summary>
    /// Custom button class that changes visual state on press and triggers scene change
    /// to "SampleScene" when clicked.
    /// </summary>
    public class CustomButton : Button, IPointerDownHandler, IPointerUpHandler
    {

        RectTransform textRect;
        Vector2 originalTextPos;

        bool isHeld;
        // Initialize references
        protected override void Awake()
        {
            base.Awake();
            textRect = GetComponentInChildren<TextMeshProUGUI>().rectTransform;
            originalTextPos = textRect.anchoredPosition;
        }
        // Apply pressed visual on pointer down
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            isHeld = true;
            ApplyPressedVisual();
        }
        // Revert visual on pointer up
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            isHeld = false;
            ApplyNormalVisual();
        }
        // Move text down to simulate button press
        private void ApplyPressedVisual()
        {
            if (textRect != null)
            {
                float height = ((RectTransform)transform).rect.height;
                float offset = height - (height * 0.86718f);
                textRect.anchoredPosition = originalTextPos - new Vector2(0, offset);
            }
        }
        // Revert to original text position
        private void ApplyNormalVisual()
        {
            if (textRect != null)
            {
                textRect.anchoredPosition = originalTextPos;
            }
        }
        // Handle state transitions to apply custom visuals and actions
        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            base.DoStateTransition(state, instant);
            if (state == SelectionState.Pressed)
            {
                ApplyPressedVisual();
                Playgame();


            }

            else
            {
                ApplyNormalVisual();
            }
        }
        // Load the main game scene and resume time
        void Playgame()
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;

        }
        
        

    }
}
