using System;
using Unity.Mathematics;
using UnityEngine;

namespace Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        private Animator _animator;
        private Collider _collider;
        
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            ResetModel();
            OnInteract(other);
        }

        private void ResetModel()
        {
            _collider.enabled = false;
            _animator.enabled = false;
            _animator.transform.rotation = Quaternion.Euler(Vector3.zero);
            _animator.transform.localPosition = Vector3.zero;
        }

        protected abstract void OnInteract(Collider other);
    }
}
