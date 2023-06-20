using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Settings;
using System.Linq;

namespace Infrastructure.Services
{
    public class SceneService : ISceneService
    {
        private readonly SceneSettings[] _sceneSettings;
        private int _activeSceneId = 1;

        public SceneSettings[] Scenes => _sceneSettings;

        public SceneService(IAssetProvider assetProvider)
        {
            _sceneSettings = assetProvider.GetScriptableObjects<SceneSettings>(AssetPath.Scene);
        }

        public void SelectScene(int id)
        {
            if (_activeSceneId != id)
                _activeSceneId = id;
        }

        public SceneSettings GetSelectedSceneSettings() =>
            GetSceneSettings(_activeSceneId);

        public SceneSettings GetSceneSettings(int id) =>
            _sceneSettings.First(s => s.Id == id);
    }
}