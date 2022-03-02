using Core;
using TMPro;
using UnityEngine;
using User;

namespace UI
{
    public class CurrencyPresenter : MonoBehaviour
    {
        private TextMeshProUGUI _currencyText;

        private void Start()
        {
            _currencyText = GetComponent<TextMeshProUGUI>();
            UpdateCurrencyText();
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnStackBuy += OnStackBuy;
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
