using SO;
using UnityEngine;
using User;

namespace Interactables
{
    public class Stackable : Interactable
    {
        [SerializeField] private SStackable stackableSettings;

        protected override ParticleSystem InteractionParticle => stackableSettings.StackParticle;

        protected override void OnInteract(Collider other)
        {
            other.GetComponent<UserStack>().AddStack();
            _animator.gameObject.SetActive(false);
            Destroy(gameObject,stackableSettings.StackDestroyDuration);
        }
    }
}
