using System;
using Core;
using TMPro;
using UnityEngine;
using User;

namespace UI
{
    public class LevelCurrencyPresenter : MonoBehaviour
    {
        private UserCurrency _userCurrency;
        private TextMeshProUGUI _levelCurrencyText;

        private void Awake()
        {
            _levelCurrencyText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _userCurrency.OnCurrencyAdded += OnCurrencyAdded;
        }

        private void OnEnable()
        {
            if(!_userCurrency) _userCurrency = FindObjectOfType<UserCurrency>();
            int currentCurrency = _userCurrency.GetCurrentCurrency();
            UpdateLevelCurrencyText(currentCurrency);
        }

        private void OnDestroy()
        {
            _userCurrency.OnCurrencyAdded -= OnCurrencyAdded;
        }
        

        private void OnCurrencyAdded(int newLevelCurrency)
        {
            UpdateLevelCurrencyText(newLevelCurrency);
        }

        private void UpdateLevelCurrencyText(int newLevelCurrency)
        {
            _levelCurrencyText.text = newLevelCurrency.ToString();
        }
    }
}
