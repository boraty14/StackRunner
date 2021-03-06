using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/User Settings")]
    public class SUser : ScriptableObject
    {
        [field :Title("Movement Settings")]
        [field: SerializeField] public float VerticalSpeed { get; private set; }
        [field: SerializeField] public float HorizontalSpeed { get; private set; }
        [field: SerializeField][field: Range(0,10f)] public float HorizontalLimit { get; private set; }
        
        [field :Title("Stack Change Settings")]
        [field: SerializeField] public int StackLimit { get; private set; }
        [field: SerializeField] public float StackChangeDuration { get; private set; }
        [field: SerializeField] public Ease StackChangeEase { get; private set; }

        [field :Title("Animation Settings")]
        [field: SerializeField][field: Range(0f,1f)] public float CrossFadePercentage { get; private set; }
        
        [field :Title("Particle Settings")]
        [field: SerializeField] public ParticleSystem WinParticle { get; private set; }
        [field: SerializeField] public ParticleSystem HitParticle { get; private set; }
        [field: SerializeField] public ParticleSystem TrailParticle { get; private set; }



    }
}
