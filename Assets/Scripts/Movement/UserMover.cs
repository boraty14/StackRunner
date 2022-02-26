using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class UserMover : MonoBehaviour
    {
        private TouchControls _touchControls;

        private void Awake()
        {
            _touchControls = new TouchControls();
        }

        private void OnEnable()
        {
            Debug.Log(1);
            _touchControls.Enable();
            _touchControls.Touch.PrimaryDrag.performed += OnDrag;
        }
        
        private void OnDisable()
        {           
            Debug.Log(2);
            _touchControls.Touch.PrimaryDrag.performed -= OnDrag;
            _touchControls.Disable();
        }

        private void OnDrag(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }

        private void OnStartTouchPrimary(InputAction.CallbackContext context)
        {
            
        }
        
        private void OnEndTouchPrimary(InputAction.CallbackContext context)
        {
            
        }
    }
}
