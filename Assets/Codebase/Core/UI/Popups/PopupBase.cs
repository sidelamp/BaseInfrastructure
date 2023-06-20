using  Infrastructure.Services;
using UnityEngine;

namespace  Core.UI.Popups
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PopupBase : MonoBehaviour
    {
        [SerializeField] private bool _isOpen;
        private BasePopupAnimation _popupAnimation;
        private CanvasGroup _canvasGroup;
        protected ICanvasService _canvasService;

        public void Initialize()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _popupAnimation = GetComponent<BasePopupAnimation>();
            _canvasService = AllServices.Container.Get<ICanvasService>();

            if (!_isOpen)
                _canvasGroup.alpha = 0;
            else
                SetActive(true);

            OnInitialization();
        }

        public void OpenPopup()
        {
            if (_isOpen) return;

            SetActive(true);

            if (!gameObject.activeInHierarchy) return;

            OnOpenPopup();
            PlayAnimation(true);
        }

        public void ClosePopup()
        {
            if (!_isOpen) return;

            SetActive(false);

            if (!gameObject.activeInHierarchy) return;

            OnClosePopup();
            PlayAnimation(false);
        }

        #region Callbacks

        protected virtual void OnInitialization()
        {
        }

        protected virtual void OnOpenPopup()
        {
        }

        protected virtual void OnClosePopup()
        {
        }

        #endregion Callbacks

        private void PlayAnimation(bool isOpen)
        {
            if (_popupAnimation != null)
                _popupAnimation.SetOpenFlag(isOpen);
        }

        private void SetActive(bool isActive)
        {
            _isOpen = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}