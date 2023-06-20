using Core.UI;
using Core.UI.Popups;
using Infrastructure.Services;
using Infrastructure.StateMachine;
using Infrastructure.States;
using UniRx;
using UnityEngine;

namespace Infrasctucture.States
{
    public class GameFinishState : IState
    {
        private GameStateMachine _gameStateMachine;
        private CompletionPopup _completionPopup;
        private GamePopup _gamePopup;
        private readonly ICanvasService _canvasService;
        private readonly LoadingCurtain _curtain;

        public GameFinishState(GameStateMachine gameStateMachine, ICanvasService canvasService, LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _canvasService = canvasService;
            _curtain = curtain;
        }

        public void Enter()
        {
            Debug.Log("<color=yellow>End game state</color>");

            if (_completionPopup == null) _completionPopup = _canvasService.GetPopup<CompletionPopup>();
            if (_gamePopup == null) _gamePopup = _canvasService.GetPopup<GamePopup>();

            _gamePopup.ClosePopup();
            _completionPopup.OpenPopup();

            Observable
                .Timer(System.TimeSpan.FromSeconds(2))
                .Subscribe(_ => _gameStateMachine.Enter<GameReadyState>());
        }

        public void Exit()
        {
            _gamePopup.OpenPopup();
            _completionPopup.ClosePopup();
            _curtain.Show();
        }
    }
}