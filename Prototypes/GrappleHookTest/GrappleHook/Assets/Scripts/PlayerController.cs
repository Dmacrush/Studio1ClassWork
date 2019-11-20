﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float NORMAL_FOV = 60f;
    private const float HOOK_FOV = 100f;

    [SerializeField]
    private float mouseSensitivity = 1f;
    [SerializeField]
    private Transform debugRaycastHit;
    [SerializeField]
    private Transform grappleHookRopeTransform;

    private CameraFov cameraFov;

    private float grappleSpeed;
    private float grappleSpeedMultiplier = 2f;
    private float grappleJumpMultiplier = 7f;
    private float grappleJumpSpeed = 40f;
    private float reachedHookPositionDistance = 1.5f;
    private float hookRopeLength;
    private float hookThrowSpeed = 70f;

    //needs to be a negative value;
    private float gravityDownForce = -50f;

    private CharacterController characterController;
    private float cameraVerticalAngle;
    private float characterVelocityY;
    private Vector3 characterVelocityMomentum;
    private Camera playerCamera;
    private Vector3 grappleHookHitPosition;

    private float hookSpeedMin = 10f;
    private float hookSpeedMax = 40f;

    private State state;

    private enum State
    {   Normal,
        HookThrown,
        UsingGrappleHook

    }



    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = transform.Find("Camera").GetComponent<Camera>();
        cameraFov = playerCamera.GetComponent<CameraFov>();
        Cursor.lockState = CursorLockMode.Locked;
        state = State.Normal;
        grappleHookRopeTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HandleCharacterLook();
                HandlePlayerMovement();
                HandleGrappleHook();
                break;
            case State.HookThrown:
                HandleHookThrow();
                HandleCharacterLook();
                HandlePlayerMovement();
                break;
            case State.UsingGrappleHook:
                HandleCharacterLook();
                HandleGrappleHookMovement();
                break;
        }
    }

    private void HandleCharacterLook()
    {
        float lookX = Input.GetAxisRaw("Mouse X");
        float lookY = Input.GetAxisRaw("Mouse Y");

        //Rotate the transform with around the local y axis
        transform.Rotate(new Vector3(0f, lookX * mouseSensitivity, 0f), Space.Self);

        cameraVerticalAngle -= lookY * mouseSensitivity;

        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);

        playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    }

    private void HandlePlayerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        float moveSpeed = 20f;

        Vector3 characterVelocity = transform.right * moveX * moveSpeed + transform.forward * moveZ * moveSpeed;

        if(characterController.isGrounded)
        {
            characterVelocityY = 0f;
            if(TestJumpInput())
            {
                float jumpSpeed = 30f;
                characterVelocityY = jumpSpeed;
            }
        }

        characterVelocityY += gravityDownForce * Time.deltaTime;

        characterVelocity.y = characterVelocityY;

        characterVelocity += characterVelocityMomentum;

        characterController.Move(characterVelocity * Time.deltaTime);

        //dampens the momentum
        if(characterVelocityMomentum.magnitude >= 0f)
        {
            float momentumDrag = 3f;
            characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
            if(characterVelocityMomentum.magnitude < .0f)
            {
                characterVelocityMomentum = Vector3.zero;
            }
        }
    }

    private void ResetGravity()
    {
        characterVelocityY = 0f;
    }

    private void HandleGrappleHook()
    {
        if(TestGrappleHookInput())
        {
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit))
            {
                debugRaycastHit.position = raycastHit.point;
                grappleHookHitPosition = raycastHit.point;
                hookRopeLength = 0f;
                grappleHookRopeTransform.gameObject.SetActive(true);
                grappleHookRopeTransform.localScale = Vector3.zero;
                state = State.HookThrown;
            }
        }
    }

    private void HandleHookThrow()
    {
        grappleHookRopeTransform.LookAt(grappleHookHitPosition);

        hookRopeLength += hookThrowSpeed * Time.deltaTime;
        grappleHookRopeTransform.localScale = new Vector3(1, 1, hookRopeLength);

        if(hookRopeLength >= Vector3.Distance(transform.position, grappleHookHitPosition))
        {
            state = State.UsingGrappleHook;
            cameraFov.SetCameraFov(HOOK_FOV);
        }

    }

    private void HandleGrappleHookMovement()
    {
        grappleHookRopeTransform.LookAt(grappleHookHitPosition);
        Vector3 hookDirection = (grappleHookHitPosition - transform.position).normalized;

        grappleSpeed = Mathf.Clamp(Vector3.Distance(transform.position, grappleHookHitPosition), hookSpeedMin, hookSpeedMax);

        //move to hook location
        characterController.Move(hookDirection * grappleSpeed * grappleSpeedMultiplier * Time.deltaTime);


        if (Vector3.Distance(transform.position, grappleHookHitPosition) < reachedHookPositionDistance)
        {
            StopGrappleHook();
        }
        if(TestGrappleHookInput())
        {
            StopGrappleHook();
        }

        if (TestJumpInput())
        {
            characterVelocityMomentum = hookDirection * grappleSpeed * grappleJumpMultiplier;
            characterVelocityMomentum += Vector3.up * grappleJumpSpeed;
            state = State.Normal;
            ResetGravity();
            StopGrappleHook();
        }
    }
    
    private void StopGrappleHook()
    {
        //Cancel GrappleHook
        state = State.Normal;
        ResetGravity();
        grappleHookRopeTransform.gameObject.SetActive(true);
        cameraFov.SetCameraFov(NORMAL_FOV);
    }

    private bool TestGrappleHookInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool TestJumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
