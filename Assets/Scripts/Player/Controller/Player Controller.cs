using System;
using UnityEngine;
using static Models;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private DefaultInput defaultInput;
    private GroundChecker groundChecker;
    
    public Vector2 input_Movement;
    public Vector2 input_View;

    private Vector3 newCameraRotation;
    private Vector3 newPlayerRotation;

    [Header("References")] 
    public Transform cameraHolder;

    [Header("Settings")] 
    public PlayerSettingsModel playerSettings;

    [Header("Gravity")] 
    public float gravityAmount;
    public float gravityMin;
    private float playerGravity;
    
    [Header("Jump")] 
    public Vector3 jumpingForce;
    private Vector3 jumpingForceVelocity;

    private Rigidbody rigidbody;
    
    
    private void Awake()
    {
        defaultInput = new DefaultInput();

        defaultInput.Character.Movement.performed += e => input_Movement = e.ReadValue<Vector2>();
        defaultInput.Character.View.performed += e => input_View = e.ReadValue<Vector2>();
        defaultInput.Character.Jump.performed += e => Jump();
        
        defaultInput.Enable();

        groundChecker = gameObject.AddComponent<GroundChecker>();

        newCameraRotation = cameraHolder.localRotation.eulerAngles;
        newPlayerRotation = transform.localRotation.eulerAngles;
        
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    private void Update()
    {
        CalculateView();
        //CalculateMovement();
        //CalculateJump();
    }

    private void CalculateView()
    {
        newPlayerRotation.y += playerSettings.ViewXSensitivity * (playerSettings.ViewXInverted ? -input_View.x : input_View.x) * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(newPlayerRotation);
        
        newCameraRotation.x += playerSettings.ViewYSensitivity * (playerSettings.ViewYInverted ? input_View.y : -input_View.y) * Time.deltaTime;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, playerSettings.viewClampYMin, playerSettings.viewClampYMax);
        
        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);
    }

    private void CalculateMovement()
    {
        var verticalSpeed = playerSettings.WalkingForwardSpeed * input_Movement.y * Time.fixedDeltaTime;
        var horizontalSpeed = playerSettings.WalkingStrafeSpeed * input_Movement.x * Time.fixedDeltaTime;
        
        var newMovementSpeed = new Vector3(horizontalSpeed, rigidbody.velocity.y, verticalSpeed);
        newMovementSpeed = transform.TransformDirection(newMovementSpeed);

        rigidbody.velocity = newMovementSpeed;
    }

    private void CalculateJump()
    {
        jumpingForce = Vector3.SmoothDamp(jumpingForce, Vector3.zero, ref jumpingForceVelocity, playerSettings.JumpingFalloff);
    }

    private void Jump()
    {
        if (groundChecker.isGrounded)
        {
            var newVelocity = rigidbody.velocity;
            newVelocity.y = Mathf.Sqrt(2f * playerSettings.JumpingForce * Mathf.Abs(Physics.gravity.y));
            rigidbody.velocity = newVelocity;
        }
        
        //rigidbody.AddForce( new Vector3(0, playerSettings.JumpingForce, 0) , ForceMode.VelocityChange);
        
        //rigidbody.velocity = Vector3.up * playerSettings.JumpingForce;

        /*jumpingForce = Vector3.up * playerSettings.JumpingHeight;
        rigidbody.AddForce(Vector3.up * playerSettings.JumpingHeight, ForceMode.VelocityChange);*/
    }
}
