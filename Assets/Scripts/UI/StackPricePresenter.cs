using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class StackPricePresenter : MonoBehaviour
    {
        private TextMeshProUGUI _stackPriceText;
        private void Start()
        {
            _stackPriceText = GetComponent<TextMeshProUGUI>();
            UpdateStackPriceText();
        }
        
        private void OnEnable()
        {
            EventBus.OnStackBuy += OnStackBuy;
        }

        private void OnDisable()
        {
            EventBus.OnStackBuy -= OnStackBuy;
        }

        private void OnStackBuy()
        {
            UpdateStackPriceText();
        }

        private void UpdateStackPriceText()
        {
            int currentStackAmount = SaveHandler.LoadStartingStack();
            int currentPrice = (int)Mathf.Pow(2, currentStackAmount);
            _stackPriceText.text = $"ADD STACK ({currentPrice}$)";
        }
    }
}
