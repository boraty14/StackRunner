using SO;
using UnityEngine;
using User;

namespace Interactables
{
    public class Obstacle : Interactable
    {
        [SerializeField] private SObstacle obstacleSettings;

        protected override ParticleSystem InteractionParticle => obstacleSettings.HitParticle;
        

        protected override void OnInteract(Collider other)
        {
            other.GetComponent<UserStack>().RemoveStack(obstacleSettings.StackDropAmount);
            _animator.gameObject.SetActive(false);
            Destroy(gameObject,obstacleSettings.ObstacleDestroyDuration);
        }
    }
}
