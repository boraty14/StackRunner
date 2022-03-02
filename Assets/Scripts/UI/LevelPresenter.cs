using System;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelPresenter : MonoBehaviour
    {
        private TextMeshProUGUI _levelText;
        private void Awake()
        {
            _levelText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            OnLevelReset();
        }

        private void OnLevelReset()
        {
            int level = SaveHandler.LoadLevel();
            _levelText.text = $"LEVEL {level+1}";
        }
        
    }
}
