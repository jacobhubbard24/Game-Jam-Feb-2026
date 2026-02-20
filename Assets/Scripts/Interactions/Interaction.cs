using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    private PlayerInput _playerInput;
    [SerializeField] private Transform _transform;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += DoInteract; // Add listeners
    }
    
    private void OnDisable()
    {
        _playerInput.actions["Interact"].performed -= DoInteract;
    }

    //Perform Raycasts
    private void DoInteract(InputAction.CallbackContext context)
    {
        if (!Physics.Raycast(_transform.position + (_transform.forward * 0.5f), _transform.forward, out var hit, 5f, interactableLayer)) return;
        if (!hit.transform.TryGetComponent(out InteractableObject interactable)) return; //Try to get the component Interactable
        interactable.Interact();
		Debug.Log("Interaction");
    }
}