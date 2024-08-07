using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;

        public static InputManager Instance
        {
            get { return _instance; }
            
        }
        private PlayerInputActions _playerControls;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            _playerControls = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        public Vector2 GetPlayerMovement()
        {
            return _playerControls.Player.Move.ReadValue<Vector2>();
        }
        public Vector2 GetMouseDelta()
        {
            return _playerControls.Player.Look.ReadValue<Vector2>();
        }

        public bool PlayerJumpedThisFrame()
        {
            return _playerControls.Player.Jump.triggered;
        }

        public bool PlayerPickUp()
        {
            return _playerControls.Player.PickUp.triggered;
        }
        
        public bool ControllCubeW()
        {
            return _playerControls.Player.ControllCube.triggered;
        }
        public bool ControllCubeS()
        {
            return _playerControls.Player.ControllS.triggered;
        }
        public bool ControllCubeD()
        {
            return _playerControls.Player.ControllD.triggered;
        }
        public bool ControllCubeA()
        {
            return _playerControls.Player.ControllA.triggered;
        }

        public bool TimeSkip()
        {
            return _playerControls.Player.TimeSkip.triggered;
        }

    }
}