using System;
using System.Collections;
using Cinemachine;
using SO;
using UnityEngine;


namespace Core
{
    //[ExecuteInEditMode][SaveDuringPlay][AddComponentMenu("")] // Hide in menu
    public class GameCameraHandler : CinemachineExtension
    {
        [SerializeField] private SGameCamera gameCameraSettings;

        private Vector3 _startingPosition;
        private float _startingX;

        protected override void Awake()
        {
            base.Awake();
            _startingPosition = transform.position;
            _startingX = transform.position.x;
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            EventBus.OnLevelReset += OnLevelReset;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
        }

        private void OnLevelReset()
        {
            StartCoroutine(LevelResetRoutine());
        }

        private IEnumerator LevelResetRoutine()
        {
            GetComponent<CinemachineVirtualCamera>().enabled = false;
            transform.position = _startingPosition;
            yield return null;
            GetComponent<CinemachineVirtualCamera>().enabled = true;
        }


        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, 
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!gameCameraSettings.LockXAxis) return;
            if (!Application.isPlaying) return;

            if (stage == CinemachineCore.Stage.Body)
            {
                var currentPosition = state.RawPosition;
                currentPosition.x = _startingX;
                state.RawPosition = currentPosition;
            }
        }
    }
}
