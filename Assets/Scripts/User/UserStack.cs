using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using DG.Tweening;
using SO;
using UnityEngine;

namespace User
{
    public class UserStack : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;
        private List<Transform> _stackables;
        private Transform _stackBasePoint;

        #region Events
        public Action<float> OnStackRatioChange;
        public Action OnHitObstacle;
        #endregion

        private void Awake()
        {
            _stackBasePoint = transform.Find("StackBasePoint");
            _stackables = new List<Transform>();
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
            DestroyStacks();
            AddStartingStacks();
        }

        private void OnLevelWin()
        {
            DestroyStacks();
        }

        private void AddStartingStacks()
        {
            int startingStackAmount = SaveHandler.LoadStartingStack();
            for (int i = 0; i < startingStackAmount; i++)
            {
                var newStack = Instantiate(userSettings.StackPrefab);
                AddStack(newStack);
            }
        }

        private void DestroyStacks()
        {
            foreach (var stackable in _stackables)
            {
                Destroy(stackable.gameObject);
            }
            _stackables.Clear();
        }

        public void AddStack(Transform stackTransform)
        {
            if (_stackables.Count == userSettings.StackLimit) return;
            stackTransform.SetParent(transform, true);
            _stackables.Add(stackTransform);
            OnStackRatioChange?.Invoke((float)_stackables.Count / userSettings.StackLimit);
            StartCoroutine(ReplaceStackRoutine(stackTransform));
        }

        public void RemoveStack(int amount)
        {
            OnHitObstacle?.Invoke();
            if (_stackables.Count == 0) return;
            if (amount > _stackables.Count) amount = _stackables.Count;
            for (int i = 0; i < amount; i++)
            {
                Transform currentStack = _stackables[_stackables.Count - 1];
                currentStack.DOScale(Vector3.zero, userSettings.StackDestroyDuration)
                    .SetEase(userSettings.StackDestroyEase).OnComplete(() => Destroy(currentStack.gameObject));
                _stackables.RemoveAt(_stackables.Count - 1);
            }
            OnStackRatioChange?.Invoke((float)_stackables.Count / userSettings.StackLimit);
        }

        private IEnumerator ReplaceStackRoutine(Transform stackTransform)
        {
            Vector3 targetLocalPos = _stackBasePoint.localPosition +
                                     _stackables.Count * userSettings.StackCollectOffset * Vector3.up;
            Sequence replaceSequence = DOTween.Sequence();
            replaceSequence.Join(stackTransform
                .DOLocalJump(targetLocalPos, userSettings.StackCollectJumpPower, 1, userSettings.StackCollectDuration)
                .SetEase(userSettings.StackCollectEase));
            replaceSequence.Join(stackTransform.DOLocalRotate(Vector3.zero, userSettings.StackCollectDuration)
                .SetEase(userSettings.StackCollectEase));
            yield return replaceSequence.WaitForCompletion();
        }
    }
}