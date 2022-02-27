using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Level")]
    public class SLevel : ScriptableObject
    {
        [field :Title("Level Settings")]
        [field: SerializeField] public GameObject LevelPrefab { get; private set; }

        public void DestroyLevel(SLevel level)
        {
           
        }
    }
}
