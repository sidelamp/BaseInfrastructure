using UnityEngine;

namespace Infrastructure.Services.Settings
{
    public abstract class SettingsBase : ScriptableObject
    {
        [SerializeField] protected int _id;

        public int Id => _id;
    }
}