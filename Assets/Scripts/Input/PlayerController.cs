using System;
using Resources.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager _inputManager;
    private Transform _cameraTransform;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = _inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        move = new Vector3(move.x, 0, move.z);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        if (_inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}