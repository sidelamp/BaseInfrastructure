using UnityEngine;

namespace  Core.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private PopupAnimation _animation;

        public void Show()
        {
            _animation.SetOpenFlag(true);
        }

        public void Close()
        {
            _animation.SetOpenFlag(false);
        }
    }
}