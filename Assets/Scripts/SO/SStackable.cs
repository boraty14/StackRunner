using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Stackable Settings")]
    public class SStackable : ScriptableObject
    {
        [field: SerializeField] public ParticleSystem StackParticle { get; private set; }
    }
}
