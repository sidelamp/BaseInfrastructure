using Core.UI;
using Infrastructure.Services;
using Infrastructure.StateMachine;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        public LoadingCurtain LoadingCurtain;
        public BaseStateMachine StateMachine;

        private void Awake()
        {
            StateMachine = new GameStateMachine(new SceneLoader(), LoadingCurtain, AllServices.Container);

            StateMachine.Enter<ServiceInitializeState>();

            DontDestroyOnLoad(LoadingCurtain);
            DontDestroyOnLoad(this);
        }
    }
}