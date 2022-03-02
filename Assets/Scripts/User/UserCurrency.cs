using System;
using Core;
using UnityEngine;

namespace User
{
    public class UserCurrency : MonoBehaviour
    {
        private int _levelCurrency = 0;
        
        public Action<int> OnCurrencyAdded;

        public void AddCurrency(int amount)
        {
            _levelCurrency += amount;
            OnCurrencyAdded?.Invoke(_levelCurrency);
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnLevelWin += OnLevelWin;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnLevelWin -= OnLevelWin;
        }

        private void OnLevelReset()
        {
            _levelCurrency = 0;
            OnCurrencyAdded?.Invoke(_levelCurrency);
        }
        
        private void OnLevelWin()
        {
            int currentCurrency = SaveHandler.LoadCurrency();
            int newCurrency = currentCurrency + _levelCurrency;
            SaveHandler.SaveCurrency(newCurrency);
        }
        
    }
}
