using Core;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using User;

namespace UI
{
    public class CurrencyPresenter : MonoBehaviour
    {
        private TextMeshProUGUI _currencyText;
        
        private void Awake()
        {
            _currencyText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnStackBuy += OnStackBuy;
            UpdateCurrencyText();
        }
        
        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnStackBuy -= OnStackBuy;
            
        }

        private void OnLevelReset()
        {
            UpdateCurrencyText();
        }

        private void OnStackBuy()
        {
            UpdateCurrencyText();
        }

        private void UpdateCurrencyText()
        {
            int currentCurrency = SaveHandler.LoadCurrency();
            _currencyText.text = $"{currentCurrency}";
        }
    }
}
