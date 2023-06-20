using Core.UI.Popups;

namespace Infrastructure.Services
{
    public interface ICanvasService : IService
    {
        void Add(PopupBase popup);

        void Remove(PopupBase popup);

        T GetPopup<T>() where T : PopupBase;

        void InitializePopups();
    }
}