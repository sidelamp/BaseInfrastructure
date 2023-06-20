using Infrastructure.Messages;
using UniRx;
using UnityEngine;

namespace Core.UI.Popups
{
    public class StartPopup : PopupBase
    {
        protected override void OnInitialization()
        {
            base.OnInitialization();
            OpenPopup();

            MessageBroker.Default
                .Receive<GameStatusMessage>()
                .Where(msg => msg.Message == LevelStatusMessage.Started)
                .Subscribe(_ => GamePlayStart())
                .AddTo(this);
        }

        private void GamePlayStart()
        {
            Debug.Log("Game play start");
        }
    }
}