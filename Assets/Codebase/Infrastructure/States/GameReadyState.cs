using Core.UI;
using Core.UI.Popups;
using Infrastructure.Messages;
using Infrastructure.Services;
using Infrastructure.StateMachine;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameReadyState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICanvasService _canvasService;
        private readonly LoadingCurtain _loadingCurtain;
        private PopupBase _startPopup;

        public GameReadyState(GameStateMachine gameStateMachine, ICanvasService canvasService, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _canvasService = canvasService;
            _loadingCurtain = loadingCurtain;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _loadingCurtain.Show();

            Debug.Log(_startPopup);
            Debug.Log(_canvasService);
            Debug.Log(_canvasService.GetPopup<StartPopup>());

            _startPopup = _startPopup != null ?
                _startPopup : _canvasService.GetPopup<StartPopup>();

            _startPopup.OpenPopup();

            MessageBroker.Default
                .Publish(new GameStatusMessage(LevelStatusMessage.Loaded));

            Observable
                .FromMicroCoroutine(Waiting)
                .Subscribe(_ => _loadingCurtain.Close());
        }

        private IEnumerator Waiting()
        {
            var duration = .5f;
            for (float t = 0f; t < duration; t += Time.deltaTime)
                yield return null;
        }
    }
}