using Infrastructure.Services.Settings;

namespace Infrastructure.Services
{
    public interface ISceneService : IService
    {
        SceneSettings[] Scenes { get; }

        SceneSettings GetSceneSettings(int id);

        SceneSettings GetSelectedSceneSettings();

        void SelectScene(int id);
    }
}