using Sirenix.OdinInspector;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Game Settings/Currency Settings")]
    public class SCurrency : ScriptableObject
    {
        [field :Title("Currency Settings")]
        [field: SerializeField] public int CurrencyValue { get; private set; }
        [field: SerializeField] public ParticleSystem CollectParticle { get; private set; }

    }
}
