using System;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelPresenter : MonoBehaviour
    {
        private TextMeshProUGUI _levelText;
        private void Start()
        {
            _levelText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
        }

        private void OnLevelReset()
        {
            int level = SaveHandler.LoadLevel();
            _levelText.text = $"LEVEL {level}";
        }
        
    }
}
