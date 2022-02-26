using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/User Settings")]
    public class SUser : ScriptableObject
    {
        [Title("Movement Settings")]
        [field: SerializeField] public float UserVerticalSpeed { get; private set; }
        [field: SerializeField] public float UserHorizontalSpeed { get; private set; }
        
        [Title("Stack Collect Settings")]
        [field: SerializeField] public int DefaultStackLimit { get; private set; }
        [field: SerializeField] public float StackCollectOffset { get; private set; }
        [field: SerializeField] public float StackCollectDuration { get; private set; }
        [field: SerializeField] public Ease StackCollectEase { get; private set; }
        [field: SerializeField] public float StackCollectJumpPower { get; private set; }
    }
}
