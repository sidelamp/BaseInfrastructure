using Core.UI;
using Infrasctucture.States;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Pool;
using Infrastructure.States;
using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : BaseStateMachine
    {
        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(ServiceInitializeState)] = new ServiceInitializeState(this, services),

                [typeof(GameSettingsInitializeState)] = new GameSettingsInitializeState(this, services.Get<ICanvasService>(),
                services.Get<IAssetProvider>(), services.Get<ISceneService>()),

                [typeof(GameReadyState)] = new GameReadyState(this, services.Get<ICanvasService>(), loadingCurtain),

                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain,
                    services.Get<ILevelFactory>(), services.Get<PoolService>()),

                [typeof(GameplayState)] = new GameplayState(this, services.Get<CanvasService>()),

                [typeof(GameFinishState)] = new GameFinishState(this, services.Get<CanvasService>(), loadingCurtain),
            };
        }
    }
}