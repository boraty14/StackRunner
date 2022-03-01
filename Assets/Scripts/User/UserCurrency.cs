using System;
using Core;
using UnityEngine;

namespace User
{
    public class UserCurrency : MonoBehaviour
    {
        private int _levelCurrency = 0;
        
        public void AddCurrency(int amount) => _levelCurrency += amount;

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            //EventBus.OnLevelWin 
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;

        }

        private void OnLevelReset()
        {
            _levelCurrency = 0;
        }
    }
}
