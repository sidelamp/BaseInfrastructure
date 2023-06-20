using Core.UI.Popups;
using Infrastructure.Services.AssetManagement;

namespace Infrastructure.Services.Builders
{
    public sealed class CanvasBuilder : CanvasBuilderBase
    {
        private enum PopupType
        { Start, Completion, Game, Skin }

        private readonly ICanvasService _canvasService;
        private readonly IAssetProvider _assetProvider;

        public CanvasBuilder(ICanvasService canvasService, IAssetProvider assetProvider)
        {
            _canvasService = canvasService;
            _assetProvider = assetProvider;
        }

        public override CanvasBuilderBase CreateCompletionPopup() =>
            CreateAndAddPopup(PopupType.Completion);

        public override CanvasBuilderBase CreateStartPopup() =>
            CreateAndAddPopup(PopupType.Start);

        public override CanvasBuilderBase CreateGamePopup() =>
            CreateAndAddPopup(PopupType.Game);

        public override void Build() =>
            _canvasService.InitializePopups();

        private CanvasBuilderBase CreateAndAddPopup(PopupType type)
        {
            var popup = _assetProvider.Instantiate<PopupBase>($"UI/Popups/{type}Popup");
            _canvasService.Add(popup);
            return this;
        }
    }
}