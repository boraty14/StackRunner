using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Game Camera Settings")]
    public class SGameCamera : ScriptableObject
    {
        [field :Title("Game Camera Settings")]
        [field: SerializeField] public bool LockXAxis { get; private set; }
    }
}
