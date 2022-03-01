using Core;
using UnityEngine;

namespace UI
{
    public class TapToPlayButton : MonoBehaviour
    {
        public void PressTapToPlay()
        {
            EventBus.OnTapToPlay?.Invoke();
        }
    }
}
