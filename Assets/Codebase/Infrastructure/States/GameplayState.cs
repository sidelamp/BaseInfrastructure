using  Core.UI.Popups;
using  Infrastructure.Messages;
using  Infrastructure.Services;
using  Infrastructure.StateMachine;
using System.Collections;
using UniRx;
using UnityEngine;

namespace  Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly CanvasService _canvasService;

        private PopupBase _gamePopup;
        private readonly CompositeDisposable _disposables = new();

        public GameplayState(GameStateMachine gameStateMachine, CanvasService canvasService)
        {
            _gameStateMachine = gameStateMachine;
            _canvasService = canvasService;
        }

        public void Exit()
        {
            _disposables.Clear();
        }

        public void Enter()
        {
            _gamePopup = _gamePopup != null ?
                _gamePopup : _canvasService.GetPopup<GamePopup>();

            _gamePopup.OpenPopup();

            MessageBroker.Default
                .Publish(new GameStatusMessage(LevelStatusMessage.Started));

            MessageBroker.Default
                .Receive<GameCompleteMessage>()
                .Subscribe(msg => CompliteLevelStatus(msg.Message))
                .AddTo(_disposables);
        }

        private void CompliteLevelStatus(CompleteMessage message)
        {
            var isWin = message == CompleteMessage.Win;

            MessageBroker.Default
                .Publish(new GameStatusMessage(LevelStatusMessage.Finished));
        }

        private IEnumerator WaitCoroutine()
        {
            var duration = .7f;
            for (float t = 0f; t < duration; t += Time.deltaTime)
                yield return null;
        }
    }
}