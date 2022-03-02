using System;
using Core;
using SO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class UserMover : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;

        private TouchControls _touchControls;
        private Vector3 _movementVector = Vector3.zero;
        private float _horizontalTarget = 0f;
        private bool _isPlaying = false;
        private Vector3 _startingPosition;


        private void Awake()
        {
            _touchControls = new TouchControls();
            _startingPosition = transform.position;
        }

        private void OnEnable()
        {
            _touchControls.Enable();
            _touchControls.Touch.PrimaryDrag.performed += OnDrag;
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnTapToPlay += OnTapToPlay;
            EventBus.OnLevelWin += OnLevelWin;
        }

        private void OnDisable()
        {
            _touchControls.Touch.PrimaryDrag.performed -= OnDrag;
            _touchControls.Disable();
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnTapToPlay -= OnTapToPlay;
            EventBus.OnLevelWin -= OnLevelWin;
        }

        private void Update()
        {
            if (!_isPlaying) return;
            _movementVector = Vector3.zero;
            SetForwardMovement();
            SetHorizontalMovement();
            transform.Translate(_movementVector);
        }
        
        private void OnLevelReset()
        {
            transform.position = _startingPosition;
        }
        
        private void OnLevelWin()
        {
            _isPlaying = false;
        }

        private void OnTapToPlay()
        {
            _isPlaying = true;
        }

        private void SetForwardMovement()
        {
            _movementVector += userSettings.VerticalSpeed * Time.deltaTime * Vector3.forward;
        }

        private void SetHorizontalMovement()
        {
            float currentHorizontalPosition = transform.position.x;
            float currentHorizontalTarget = Mathf.Lerp(currentHorizontalPosition, _horizontalTarget,
                Time.deltaTime * userSettings.HorizontalSpeed);
            float newHorizontalMovement = currentHorizontalTarget - currentHorizontalPosition;
            _movementVector += newHorizontalMovement * Vector3.right;
        }

        private void OnDrag(InputAction.CallbackContext context)
        {
            float horizontalInput = context.ReadValue<Vector2>().x;
            Vector3 currentPosition = transform.position;
            _horizontalTarget = Mathf.Clamp(currentPosition.x + horizontalInput, 
                -userSettings.HorizontalLimit, userSettings.HorizontalLimit);
        }
    }
}