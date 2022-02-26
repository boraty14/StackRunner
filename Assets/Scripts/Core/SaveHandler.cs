using UnityEngine;
using Utils;

namespace Core
{
    public class SaveHandler : MonoBehaviourSingleton<SaveHandler>
    {
        private const string LevelString = "Level";
        private const string CurrencyString = "Currency";
        private const string StackLimitString = "StackLimit";

        public void SaveLevel(int level) => PlayerPrefs.SetInt(LevelString, level);

        public void SaveCurrency(int currency) => PlayerPrefs.SetInt(CurrencyString, currency);

        public void SaveStackLimit(int stackLimit) => PlayerPrefs.SetInt(StackLimitString, stackLimit);
    }
}
