using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Builders;
using Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class GameSettingsInitializeState : IState
    {
        private GameStateMachine _gameStateMachine;
        private readonly ICanvasService _canvasService;
        private readonly IAssetProvider _assetProvider;
        private readonly ISceneService _sceneService;
        private const int _sceneMenu = 0;

        public GameSettingsInitializeState(GameStateMachine gameStateMachine, ICanvasService canvasService,
            IAssetProvider assetProvider, ISceneService sceneService)
        {
            _gameStateMachine = gameStateMachine;
            _canvasService = canvasService;
            _assetProvider = assetProvider;
            _sceneService = sceneService;
        }

        public void Enter()
        {
            Debug.Log("<color=yellow>Game initialize</color>");

            CreatePopups();
            LoadSceneMenu();

            _gameStateMachine.Enter<GameReadyState>();
        }

        public void Exit()
        {
        }

        private void LoadSceneMenu()
        {
            var scene = _sceneService.GetSceneSettings(_sceneMenu);
            SceneManager.LoadScene(scene.SceneName);
        }

        private void CreatePopups()
        {
            var builder = new CanvasBuilder(_canvasService, _assetProvider);
            builder
                .CreateStartPopup()
                .CreateCompletionPopup()
                .CreateGamePopup()
                .Build();
        }
    }
}