using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class ToggleVisibility : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private bool visible = false;

        private void Awake()
        {
            if (visible) Show();
            if (!visible) Hide();
        }

        public void Toggle()
        {
            visible = !visible;
            if (visible) Show();
            if (!visible) Hide();
        }

        private void Hide()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }

        private void Show()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
}