using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    [Header("Input Action Asset")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Vector2 currentInput;
    [Header("Character Info")]
    [SerializeField] private float moveSpeed = 0.015f;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private CharacterController characterController;
    
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform cameraTarget;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 0.02f;
    [SerializeField] private float minPitch = -75f;
    [SerializeField] private float maxPitch = 80f;
    [SerializeField] private float rotationSmoothSpeed = 15f; // lower = snappier, higher = smoother

    private float targetYaw;
    private float targetPitch;
    private float yaw = 0f;
    private float pitch = 0f;

    private void Awake(){
        playerInput = GetComponent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    private void LateUpdate()
    {
        HandleLook();
    }


    // Handles the camera and player rotation from mouse input
    private void HandleLook()
    {
        var rawLook = playerInput.actions["Look"].ReadValue<Vector2>();

        targetYaw += rawLook.x * mouseSensitivity;
        targetPitch -= rawLook.y * mouseSensitivity;
        targetPitch = Mathf.Clamp(targetPitch, minPitch, maxPitch);

        // Calculate rotations
        yaw = Mathf.Lerp(yaw, targetYaw, rotationSmoothSpeed * Time.deltaTime);
        pitch = Mathf.Lerp(pitch, targetPitch, rotationSmoothSpeed * Time.deltaTime);
        
        // Apply smoothed rotations
        cameraTarget.rotation = Quaternion.Euler(pitch, yaw, 0f);
        orientation.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    private void HandleMovement()
    {
        var clampedRotation = orientation.rotation;

        currentInput = playerInput.actions["Move"].ReadValue<Vector2>();
        moveDirection = orientation.forward * currentInput.y * moveSpeed + orientation.right * currentInput.x * moveSpeed;

        characterController.Move(moveDirection);
    }
}