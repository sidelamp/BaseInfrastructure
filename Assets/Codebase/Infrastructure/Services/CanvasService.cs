using Codebase.Core.UI.Popups;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Codebase.Infrastructure.Services
{
    public class CanvasService : IService
    {
        private readonly Canvas _canvas;
        private readonly List<PopupBase> _popups = new();

        public CanvasService(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void Add(PopupBase popup)
        {
            _popups.Add(popup);

            popup.transform.SetParent(_canvas.transform);
            popup.GetComponent<Canvas>().overrideSorting = true;
            
            SetStretch(popup);
        }

        public T GetPopup<T>() where T : PopupBase =>
            _popups.FirstOrDefault(p => p is T) as T;
            
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
