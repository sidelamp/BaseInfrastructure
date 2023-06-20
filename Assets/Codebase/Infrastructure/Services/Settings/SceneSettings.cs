using UnityEngine;

namespace  Infrastructure.Services.Settings
{
    [CreateAssetMenu(fileName = "SceneSettings", menuName = "Create scene settings", order = 51)]
    public class SceneSettings : SettingsBase
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _isLevel;

        public string SceneName => _name;
        public Sprite Icon => _icon;
        public bool IsMap => _isLevel;
    }
}