using Cinemachine;
using SO;
using UnityEngine;


namespace Core
{
    //[ExecuteInEditMode][SaveDuringPlay][AddComponentMenu("")] // Hide in menu
    public class GameCameraHandler : CinemachineExtension
    {
        [SerializeField] private SGameCamera gameCameraSettings;

        private float _startingX;
        
        void Start()
        {
            _startingX = transform.position.x;
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, 
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!Application.isPlaying) return;
            if (!gameCameraSettings.LockXAxis) return;
            if (stage == CinemachineCore.Stage.Body)
            {
                var currentPosition = state.RawPosition;
                currentPosition.x = _startingX;
                state.RawPosition = currentPosition;
            }
        }
    }
}
