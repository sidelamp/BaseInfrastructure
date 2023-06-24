using Core.UI;
using Infrastructure.Services;
using Infrastructure.StateMachine;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        public LoadingCurtain loadingCurtain;
        public BaseStateMachine stateMachine;

        private void Awake()
        {
            loadingCurtain.Initialize();
            stateMachine = new GameStateMachine(new SceneLoader(), loadingCurtain, AllServices.Container);
            stateMachine.Enter<ServiceInitializeState>();

            DontDestroyOnLoad(loadingCurtain);
            DontDestroyOnLoad(this);
        }
    }
}