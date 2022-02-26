using UnityEngine;
using User;

namespace Animations
{
    public class UserAnimator : MonoBehaviour
    {
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

        private void OnDisable()
        {
            _userStack.OnStackRatioChange -= OnStackRatioChange;
        }

        private void OnStackRatioChange(float newRatio)
        {
            _animator.SetFloat(StackRatio,newRatio);
        }
    }
}
