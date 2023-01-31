﻿using Codebase.Core.UI;
using Codebase.Core.UI.Popups;
using Codebase.Infrastructure.Services.AssetManagement;
using UnityEngine;

namespace Codebase.Infrastructure.Services.Factories
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetProvider _assetProvider;

        private StartPopup _startPopup;
        private OverlayPopup _overlayPopup;
        private WinPopup _winPopup;
        private LosePopup _losePopup;
        private Canvas _mainCanvas;

        public UiFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            InitializePopups();
        }

        private void InitializePopups()
        {
            CreateMainCanvas();
            GetStartPopup();
            GetOverlayPopup();
            GetWinPopup();
            GetLosePopup();
        }

        private void CreateMainCanvas()
        {
            if (_mainCanvas == null)
                _mainCanvas = _assetProvider.Instantiate<Canvas>(AssetPath.MainCanvas);
            Object.DontDestroyOnLoad(_mainCanvas);
        }

        public StartPopup GetStartPopup()
        {
            if (_startPopup == null)
            {
                _startPopup = _assetProvider.Instantiate<StartPopup>(AssetPath.StartPopup);
                AddToMainCanvas(_startPopup);
            }
            return _startPopup;
        }

        public OverlayPopup GetOverlayPopup()
        {
            if (_overlayPopup == null)
            {
                _overlayPopup = _assetProvider.Instantiate<OverlayPopup>(AssetPath.OverlayPopup);
                AddToMainCanvas(_overlayPopup);
            }
            return _overlayPopup;
        }

        public WinPopup GetWinPopup()
        {
            if (_winPopup == null)
            {
                _winPopup = _assetProvider.Instantiate<WinPopup>(AssetPath.WinPopup);
                AddToMainCanvas(_winPopup);
            }
            return _winPopup;
        }

        public LosePopup GetLosePopup()
        {
            if (_losePopup == null)
            {
                _losePopup = _assetProvider.Instantiate<LosePopup>(AssetPath.LosePopup);
                AddToMainCanvas(_losePopup);
            }
            return _losePopup;
        }

        private void AddToMainCanvas(PopupBase popup)
        {
            popup.transform.SetParent(_mainCanvas.transform);
            popup.GetComponent<Canvas>().overrideSorting = true;
        }
    }
}