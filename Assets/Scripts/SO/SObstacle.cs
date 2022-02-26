using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Obstacle Settings")]
    public class SObstacle : ScriptableObject
    {
        [Title("Obstacle Settings")]
        [field: SerializeField] public int StackDropAmount { get; private set; }
    }
}
