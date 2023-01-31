using System;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Core.UI.Popups
{
    public class WinPopup : PopupBase
    {
        [SerializeField] private Button _nextButton;
        
        public event Action OnNextLevel;

        protected override void OnInitialization()
        {
            base.OnInitialization();
            _nextButton.onClick.AddListener(OnNextButtonClick);
        }
        
        protected override void OnOpenPopup()
        {
            base.OnOpenPopup();
            _nextButton.interactable = true;
        }
        
        private void OnNextButtonClick()
        {
            _nextButton.interactable = false;
            OnNextLevel?.Invoke();
        }
    }
}