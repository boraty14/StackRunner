using Core;
using SO;
using UnityEngine;

namespace UI
{
    public class AddStackButton : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;
        public void AddStack()
        {
            int currentStackAmount = SaveHandler.LoadStartingStack();
            if (currentStackAmount >= userSettings.StackLimit) return;
            int currentPrice = (int)Mathf.Pow(2, currentStackAmount);
            Debug.Log(currentPrice);
            int currentCurrency = SaveHandler.LoadCurrency();
            if (currentCurrency < currentPrice) return;
            currentCurrency -= currentPrice;
            SaveHandler.SaveCurrency(currentCurrency);
            SaveHandler.SaveStartingStack(currentStackAmount + 1);
            EventBus.OnStackBuy?.Invoke();
        }
    }
}
