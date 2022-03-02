using System;
using Cinemachine;
using Core;
using UnityEngine;

namespace Cameras
{
    public class WinCameraHandler : MonoBehaviour
    {
        private CinemachineVirtualCamera _vCam;
        private void Awake()
        {
            _vCam = GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnLevelWin += OnLevelWin;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnLevelWin -= OnLevelWin;
        }

        private void OnLevelReset()
        {
            _vCam.enabled = false;
        }

        private void OnLevelWin()
        {
            _vCam.enabled = true;
        }
    }
}
