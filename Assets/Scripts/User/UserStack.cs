using System;
using Core;
using DG.Tweening;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace User
{
    public class UserStack : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;
        [SerializeField] private Image stackBar;

        private float _targetStackBarAmount = 0f;

        #region Events
        public Action<float> OnStackRatioChange;
        public Action OnHitObstacle;
        #endregion

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnLevelWin += OnLevelWin;
            EventBus.OnStackBuy += OnStackBuy;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnLevelWin -= OnLevelWin;
            EventBus.OnStackBuy -= OnStackBuy;
        }

        private void OnLevelReset()
        {
            AddStartingStacks();
        }

        private void OnStackBuy()
        {
            ResetStacks();
            AddStartingStacks();
        }

        private void OnLevelWin()
        {
            ResetStacks();
        }

        private void AddStartingStacks()
        {
            int startingStackAmount = SaveHandler.LoadStartingStack();
            stackBar.fillAmount = (float)startingStackAmount / userSettings.StackLimit;
            _targetStackBarAmount = stackBar.fillAmount;
        }

        private void ResetStacks()
        {
            stackBar.fillAmount = 0f;
            _targetStackBarAmount = 0f;
        }

        public void AddStack()
        {
            float changeRatio = 1f / userSettings.StackLimit;
            ChangeStackAmount(changeRatio);
            //OnStackRatioChange?.Invoke((float)_stackables.Count / userSettings.StackLimit);
        }

        public void RemoveStack(int amount)
        {
            OnHitObstacle?.Invoke();
            float changeRatio = -amount *  (1f / userSettings.StackLimit);
            ChangeStackAmount(changeRatio);
            //OnStackRatioChange?.Invoke((float)_stackables.Count / userSettings.StackLimit);
        }

        private void ChangeStackAmount(float changeAmount)
        {
            stackBar.DOKill();
            _targetStackBarAmount += changeAmount;
            _targetStackBarAmount = Mathf.Clamp(_targetStackBarAmount, 0f, 1f);
            OnStackRatioChange?.Invoke(_targetStackBarAmount);
            stackBar.DOFillAmount(_targetStackBarAmount, userSettings.StackChangeDuration)
                .SetEase(userSettings.StackChangeEase);
        }
    }
}