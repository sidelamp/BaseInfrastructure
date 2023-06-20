using Core.UI;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Pool;
using Infrastructure.StateMachine; 

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly ILevelFactory _levelFactory;
        private PoolService _poolService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            LoadingCurtain loadingCurtain, ILevelFactory levelFactory, PoolService poolService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _levelFactory = levelFactory;
            _poolService = poolService;
        }

        public void Enter(string sceneName)
        {
            _poolService.Clear();
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(sceneName, false, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _gameStateMachine.Enter<GameReadyState>();
        }
    }
}