using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Obstacle Settings")]
    public class SObstacle : ScriptableObject
    {
        [field :Title("Obstacle Settings")]
        [field: SerializeField] public int StackDropAmount { get; private set; }
        [field: SerializeField] public float ObstacleDestroyDuration { get; private set; }

        [field: SerializeField] public ParticleSystem HitParticle { get; private set; }

    }
}
