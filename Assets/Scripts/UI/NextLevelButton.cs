using System.Collections;
using Core;
using UnityEngine;

namespace UI
{
    public class NextLevelButton : MonoBehaviour
    {
        public void PressNextLevel()
        {
            EventBus.OnPressNextLevel?.Invoke();
        }
    }
}
