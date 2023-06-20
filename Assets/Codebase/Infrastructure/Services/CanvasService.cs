using Core.UI.Popups;
using Infrastructure.Services.AssetManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CanvasService : ICanvasService
    {
        private Transform _canvasTransform;
        private readonly List<PopupBase> _popups = new();
        private readonly IAssetProvider _assetProvider;

        public CanvasService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            CreateCanvas();
        }

        public void InitializePopups()
        {
            foreach (var popup in _popups)
                popup.Initialize();
        }

        public void Add(PopupBase popup)
        {
            _popups.Add(popup);

            popup.transform.SetParent(_canvasTransform, false);
            popup.GetComponent<Canvas>().overrideSorting = true;

            SetStretch(popup);
        }

        public void Remove(PopupBase popup)
        {
            _popups.Remove(popup);
            Object.Destroy(popup.gameObject);
        }

        public T GetPopup<T>() where T : PopupBase =>
            _popups.FirstOrDefault(p => p is T) as T;

        private void CreateCanvas()
        {
            var obj = _assetProvider.GetObject<Canvas>(AssetPath.Canvas);
            var canvas = Object.Instantiate(obj);
            _canvasTransform = canvas.transform;

            Object.DontDestroyOnLoad(canvas.gameObject);
        }

        private void SetStretch(PopupBase popup)
        {
            var rectTransform = popup.GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}