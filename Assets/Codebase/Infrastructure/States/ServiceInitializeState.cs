using Core.Ads;
using Core.Analytics;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Levels;
using Infrastructure.Services.Pool;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Settings;
using Infrastructure.StateMachine;
using UnityEngine;

namespace Infrastructure.States
{
    public class ServiceInitializeState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        public ServiceInitializeState(GameStateMachine stateMachine, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _services = allServices;

            RegisterServices();
        }

        public void Enter()
        {
            Debug.Log("<color=yellow>services initialize</color>");
            _stateMachine.Enter<GameSettingsInitializeState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterAssetProvider();
            RegisterCanvasService();
            RegisterGetSetService();
            RegisterSaveLoadService();
            RegisterGameSettings();
            RegisterSceneService();

            RegisterAdsModule();
            RegisterAnalyticsModule();

            RegisterLevelFactory();
            RegisterPoolService();
            RegisterLevelService();
        }

        private void RegisterGameSettings()
        {
            GameSettings gameSettings = _services.Get<IAssetProvider>()
                .GetScriptableObject<GameSettings>(AssetPath.GameSettings);

            _services.RegisterSingle(gameSettings);
        }

        private void RegisterSceneService()
        {
            _services.RegisterSingle<ISceneService>(new SceneService(_services.Get<IAssetProvider>()));
        }

        private void RegisterAdsModule()
        {
            _services.RegisterSingle<IAdsModule>(
                new AdsModule());
        }

        private void RegisterAnalyticsModule()
        {
            _services.RegisterSingle<IAnalyticsModule>(
                new AnalyticsModule());
        }

        private void RegisterAssetProvider()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
        }

        private void RegisterGetSetService()
        {
            _services.RegisterSingle<IPlayerPrefsService>(new PlayerPrefsService());
        }

        private void RegisterSaveLoadService()
        {
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService());
        }

        private void RegisterLevelFactory()
        {
            _services.RegisterSingle<ILevelFactory>(new LevelFactory(_services.Get<IAssetProvider>()));
        }

        private void RegisterPoolService()
        {
            _services.RegisterSingle(new PoolService());
        }

        private void RegisterLevelService()
        {
            _services.RegisterSingle<ILevelService>(new LevelService());
        }

        private void RegisterCanvasService()
        {
            _services.RegisterSingle<ICanvasService>(new CanvasService(_services.Get<IAssetProvider>()));
        }
    }
}