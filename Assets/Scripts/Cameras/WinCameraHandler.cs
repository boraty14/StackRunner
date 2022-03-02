using System;
using Cinemachine;
using Core;
using Level;
using UnityEngine;

namespace Cameras
{
    public class WinCameraHandler : MonoBehaviour
    {
        private CinemachineVirtualCamera _vCam;
        private LevelHandler _levelHandler;
        
        private void Awake()
        {
            _vCam = GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            if (!_levelHandler) _levelHandler = FindObjectOfType<LevelHandler>();
            _levelHandler.OnGoNextLevel += OnGoNextLevel;
            EventBus.OnLevelWin += OnLevelWin;
        }

        private void OnDisable()
        {
            _levelHandler.OnGoNextLevel -= OnGoNextLevel;
            EventBus.OnLevelWin -= OnLevelWin;
        }

        private void OnGoNextLevel()
        {
            _vCam.enabled = false;
        }

        private void OnLevelWin()
        {
            _vCam.enabled = true;
        }
    }
}
