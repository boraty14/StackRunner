using SO;
using UnityEngine;
using Utils;

namespace Core
{
    public static class SaveHandler
    {
        private const string LevelString = "Level";
        private const string CurrencyString = "Currency";
        private const string StartingStackString = "StartingStack";

        public static void SaveLevel(int level) => PlayerPrefs.SetInt(LevelString, level);

        public static void SaveCurrency(int currency) => PlayerPrefs.SetInt(CurrencyString, currency);

        public static void SaveStartingStack(int stackLimit) => PlayerPrefs.SetInt(StartingStackString, stackLimit);
        
        public static int LoadLevel() => PlayerPrefs.GetInt(LevelString, 0);
        
        public static int LoadCurrency() => PlayerPrefs.GetInt(CurrencyString, 0);
        
        public static int LoadStartingStack() => PlayerPrefs.GetInt(StartingStackString, 0);

        
    }
}
