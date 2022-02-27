using System;
using Core;
using SO;
using UnityEngine;
using User;

namespace Animations
{
    public class UserAnimator : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;
        
        private Animator _animator;
        private UserStack _userStack;
        private static readonly int StackRatio = Animator.StringToHash("stackRatio");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        
        private void Start()
        {
            _userStack = GetComponent<UserStack>();
            _userStack.OnStackRatioChange += OnStackRatioChange;
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnTapToPlay += OnTapToPlay;
            EventBus.OnLevelWin += OnLevelWin;
        }
        
        private void OnDisable()
        {
            _userStack.OnStackRatioChange -= OnStackRatioChange;
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnTapToPlay -= OnTapToPlay;
            EventBus.OnLevelWin -= OnLevelWin;
        }

        private void OnLevelReset()
        {
            _animator.Play("Idle");
        }
        
        private void OnTapToPlay()
        {
            _animator.CrossFade("RunState",userSettings.CrossFadePercentage);
        }
        
        private void OnLevelWin()
        {
            _animator.CrossFade("Dance",userSettings.CrossFadePercentage);
            Debug.Log("alo");
        }


        private void OnStackRatioChange(float newRatio)
        {
            _animator.SetFloat(StackRatio,newRatio);
        }
    }
}
