using Infrastructure.Services;
using Infrastructure.Services.Levels;

namespace Core.UI.Popups
{
    public class CompletionPopup : PopupBase
    {
        private ILevelService _levelService;

        protected override void OnInitialization()
        {
            base.OnInitialization();

            _levelService = AllServices.Container.Get<ILevelService>();
        }

        protected override void OnOpenPopup()
        {
            base.OnOpenPopup();
        }
    }
}