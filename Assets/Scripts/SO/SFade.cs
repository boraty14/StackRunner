using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Fade Settings")]
    public class SFade : ScriptableObject
    {
        [field :Title("Fade Settings")]
        [field: SerializeField] public float FadeDuration { get; private set; }
        [field: SerializeField] public Ease FadeEase{ get; private set; }

    }
}
