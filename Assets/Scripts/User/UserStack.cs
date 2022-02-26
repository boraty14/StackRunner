using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using SO;
using UnityEngine;

namespace User
{
    public class UserStack : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;
        private Stack<Transform> _stackables;
        private Transform _stackBasePoint;
        private int _stackLimit;

        #region Events

        public Action<float> OnStackRatioChange;

        #endregion

        private void Awake()
        {
            _stackBasePoint = transform.Find("StackBasePoint");
            _stackables = new Stack<Transform>();
        }

        public void AddStack(Transform stackTransform)
        {
            if (_stackables.Count == userSettings.StackLimit) return;
            stackTransform.SetParent(transform, true);
            _stackables.Push(stackTransform);
            OnStackRatioChange?.Invoke((float)_stackables.Count / userSettings.StackLimit);
            StartCoroutine(ReplaceStackRoutine(stackTransform));
        }

        public void RemoveStack(int amount)
        {
            if (_stackables.Count == 0) return;
            if (amount > _stackables.Count) amount = _stackables.Count;
            //TODO remove stacks
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
            
            //TODO add spring joint
        }
    }
}