using System;
using Core;
using UnityEngine;

namespace Level
{
    public class FinishLine : MonoBehaviour
    {
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _collider.enabled = false;
            EventBus.OnLevelWin?.Invoke();
        }
    }
}
