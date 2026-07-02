using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;

    private CharacterController characterController;
    private PlayerControls playerControls;
    private Vector2 moveInput;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = playerControls.Player.Move.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        bool sprint = IsSprinting(); //playerControls.Player.Sprint.IsPressed();

        float currentSpeed = sprint ? sprintSpeed : walkSpeed;

        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

        if(IsAttacking())
        {
            // Handle attack logic here
            Debug.Log("Attack!");
        }

    }

    private bool IsSprinting()
    {
        return playerControls.Player.Sprint.IsPressed();
    }

    private bool IsAttacking() 
    {
        return playerControls.Player.Attack.triggered;
    }
}