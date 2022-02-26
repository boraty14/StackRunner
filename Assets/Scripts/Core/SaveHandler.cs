using SO;
using UnityEngine;
using Utils;

namespace Core
{
    public class SaveHandler : MonoBehaviourSingleton<SaveHandler>
    {
        [SerializeField] private SUser userSettings;
        
        private const string LevelString = "Level";
        private const string CurrencyString = "Currency";
        private const string StartingStackString = "StartingStack";

        public void SaveLevel(int level) => PlayerPrefs.SetInt(LevelString, level);

        public void SaveCurrency(int currency) => PlayerPrefs.SetInt(CurrencyString, currency);

        public void SaveStartingStack(int stackLimit) => PlayerPrefs.SetInt(StartingStackString, stackLimit);
        
        public int LoadLevel() => PlayerPrefs.GetInt(LevelString, 0);
        
        public int LoadCurrency() => PlayerPrefs.GetInt(CurrencyString, 0);
        
        public int LoadStackLimit() => PlayerPrefs.GetInt(StartingStackString, userSettings.StackLimit);

        
    }
}
