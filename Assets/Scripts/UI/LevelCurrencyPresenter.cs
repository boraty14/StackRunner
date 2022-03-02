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
            _userCurrency = FindObjectOfType<UserCurrency>();
            _userCurrency.OnCurrencyAdded += OnCurrencyAdded;
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            UpdateLevelCurrencyText(0);
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
        }

        private void OnDestroy()
        {
            _userCurrency.OnCurrencyAdded -= OnCurrencyAdded;
        }

        private void OnLevelReset()
        {
            UpdateLevelCurrencyText(0);
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
