using System;
using UnityEngine;

namespace Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            OnInteract(other);
        }

        protected abstract void OnInteract(Collider other);
    }
}
