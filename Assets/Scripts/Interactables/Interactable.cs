using System;
using Unity.Mathematics;
using UnityEngine;

namespace Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        protected Animator _animator;
        private Collider _collider;

        protected abstract ParticleSystem InteractionParticle { get;}
        
        protected abstract void OnInteract(Collider other);
        
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            Instantiate(InteractionParticle, transform);
            _collider.enabled = false;
            OnInteract(other);
        }
    }
}
