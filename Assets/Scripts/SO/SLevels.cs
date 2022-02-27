using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Levels Settings")]
    public class SLevels : ScriptableObject
    {
        [field :Title("Levels")]
        [field: SerializeField] public List<SLevel> Levels { get; private set; }
    }
}
