using Core;
using UnityEngine;

namespace UI
{
    public class AddStackButton : MonoBehaviour
    {
        public void AddStack()
        {
            int currentStackAmount = SaveHandler.LoadStartingStack();
            int currentPrice = (int)Mathf.Pow(2, currentStackAmount);
            int currentCurrency = SaveHandler.LoadCurrency();
            if (currentCurrency < currentPrice) return;
            currentCurrency -= currentPrice;
            SaveHandler.SaveCurrency(currentCurrency);
            SaveHandler.SaveStartingStack(currentStackAmount + 1);
            EventBus.OnStackBuy?.Invoke();
        }
    }
}
