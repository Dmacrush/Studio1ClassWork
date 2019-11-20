using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelGrapple : MonoBehaviour
{
    private const float NORMAL_FOV = 60f;
    private const float HOOK_FOV = 100f;

    [SerializeField]
    private float mouseSensitivity = 1f;
    [SerializeField]
    private Transform debugRaycastHitRight;
    [SerializeField]
    private Transform debugRaycastHitLeft;
    [SerializeField]
    private Transform grappleHookRopeTransformRight;
    [SerializeField]
    private Transform grappleHookRopeTransformLeft;

    private CameraFov cameraFov;

    private float grappleSpeed;
    private float grappleSpeedMultiplier = 2f;
    private float grappleJumpMultiplier = 7f;
    private float grappleJumpSpeed = 40f;
    private float maxGrappleDistance = 40f;
    private float reachedHookPositionDistanceLeft = 1.5f;
    private float reachedHookPositionDistanceRight = 1.5f;
    private float hookRopeLengthRight;
    private float hookRopeLengthLeft;
    private float hookThrowSpeed = 70f;

    //needs to be a negative value;
    private float gravityDownForce = -50f;

    private CharacterController characterController;
    private float cameraVerticalAngle;
    private float characterVelocityY;
    private Vector3 characterVelocityMomentum;
    private Camera playerCamera;
    private Vector3 grappleHookHitPositionLeft;
    private Vector3 grappleHookHitPositionRight;
    private Vector3 hookDirection;

    private float hookSpeedMin = 10f;
    private float hookSpeedMax = 30f;

    private State state;

    private enum State
    {
        Normal,
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
        grappleHookRopeTransformRight.gameObject.SetActive(false);
        grappleHookRopeTransformLeft.gameObject.SetActive(false);
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
                HandleHookThrowRight();
                HandleHookThrowLeft();
                HandleCharacterLook();
                HandlePlayerMovement();
                break;
            case State.UsingGrappleHook:
                HandleCharacterLook();
                HandleGrappleHookMovementLeft();
                HandleGrappleHookMovementRight();
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

        if (characterController.isGrounded)
        {
            characterVelocityY = 0f;
            if (TestJumpInput())
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
        if (characterVelocityMomentum.magnitude >= 0f)
        {
            float momentumDrag = 3f;
            characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
            if (characterVelocityMomentum.magnitude < .0f)
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
        if (TestGrappleRightHookInput())
        {
            Ray rightHook = playerCamera.ViewportPointToRay(new Vector3(0.75f, 0.5f, 0));
            RaycastHit rightHitInfo;

            if (Physics.Raycast(rightHook, out rightHitInfo))
            {
                debugRaycastHitRight.position = rightHitInfo.point;
                grappleHookHitPositionRight = rightHitInfo.point;
                hookRopeLengthRight = 0f;
                grappleHookRopeTransformRight.gameObject.SetActive(true);
                grappleHookRopeTransformRight.localScale = Vector3.zero;
                state = State.HookThrown;
            }
            
            //first attempt at grapple hook
            #region 
            /*
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit, maxGrappleDistance))
            {
                debugRaycastHit.position = raycastHit.point;
                grappleHookHitPosition = raycastHit.point;
                hookRopeLength = 0f;
                grappleHookRopeTransform.gameObject.SetActive(true);
                grappleHookRopeTransform.localScale = Vector3.zero;
                state = State.HookThrown;
            }
            */
            #endregion
        }


        if (TestGrappleLeftHookInput())
        {

            Ray leftHook = playerCamera.ViewportPointToRay(new Vector3(0.25f, 0.5f, 0));
            RaycastHit leftHitInfo;

            if (Physics.Raycast(leftHook, out leftHitInfo))
            {
                debugRaycastHitLeft.position = leftHitInfo.point;
                grappleHookHitPositionLeft = leftHitInfo.point;
                hookRopeLengthLeft = 0f;
                grappleHookRopeTransformLeft.gameObject.SetActive(true);
                grappleHookRopeTransformLeft.localScale = Vector3.zero;
                state = State.HookThrown;
            }

            #region
            /*
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit, maxGrappleDistance))
            {
                debugRaycastHit.position = raycastHit.point;
                grappleHookHitPosition = raycastHit.point;
                hookRopeLength = 0f;
                grappleHookRopeTransform.gameObject.SetActive(true);
                grappleHookRopeTransform.localScale = Vector3.zero;
                state = State.HookThrown;
            }
            */
            #endregion
        }
    }

    private void HandleHookThrowRight()
    {
        grappleHookRopeTransformRight.LookAt(grappleHookHitPositionRight);

        hookRopeLengthRight += hookThrowSpeed * Time.deltaTime;
        grappleHookRopeTransformRight.localScale = new Vector3(1, 1, hookRopeLengthRight);

        if (hookRopeLengthRight >= Vector3.Distance(transform.position, grappleHookHitPositionRight))
        {
            state = State.UsingGrappleHook;
            cameraFov.SetCameraFov(HOOK_FOV);

        }

    }

    private void HandleHookThrowLeft()
    {
        grappleHookRopeTransformLeft.LookAt(grappleHookHitPositionLeft);

        hookRopeLengthLeft += hookThrowSpeed * Time.deltaTime;
        grappleHookRopeTransformLeft.localScale = new Vector3(1, 1, hookRopeLengthLeft);

        if (hookRopeLengthLeft >= Vector3.Distance(transform.position, grappleHookHitPositionLeft))
        {
            state = State.UsingGrappleHook;
            cameraFov.SetCameraFov(HOOK_FOV);

        }

    }

    private void HandleGrappleHookMovementRight()
    {
        grappleHookRopeTransformRight.LookAt(grappleHookHitPositionRight);
        hookDirection = (grappleHookHitPositionRight - transform.position).normalized;

        grappleSpeed = Mathf.Clamp(Vector3.Distance(transform.position, grappleHookHitPositionRight), hookSpeedMin, hookSpeedMax);

        //move to hook location
        characterController.Move(hookDirection * grappleSpeed * grappleSpeedMultiplier * Time.deltaTime);

        if (GrappleRightHeld())
        {
            
        }
        else
        {
            if (Vector3.Distance(transform.position, grappleHookHitPositionRight) < reachedHookPositionDistanceRight)
            {
                StopGrappleHook();
            }
            if (TestGrappleRightHookInput())
            {
                StopGrappleHook();
            }
            if(GrappleRightUpInput())
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
    }

    private void HandleGrappleHookMovementLeft()
    {
        grappleHookRopeTransformLeft.LookAt(grappleHookHitPositionLeft);
        hookDirection = (grappleHookHitPositionLeft - transform.position).normalized;

        grappleSpeed = Mathf.Clamp(Vector3.Distance(transform.position, grappleHookHitPositionLeft), hookSpeedMin, hookSpeedMax);

        //move to hook location
        characterController.Move(hookDirection * grappleSpeed * grappleSpeedMultiplier * Time.deltaTime);

        if (GrappleLeftHeld())
        {

        }
        else
        {
            if (Vector3.Distance(transform.position, grappleHookHitPositionLeft) < reachedHookPositionDistanceLeft)
            {
                StopGrappleHook();
            }
            if (TestGrappleLeftHookInput())
            {
                StopGrappleHook();
            }
            if(GrappleLeftUpInput())
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
    }

    /*
    private void DuelGrapplesUsed()
    {
        Vector3 midPoint = (grappleHookHitPositionLeft + grappleHookHitPositionRight) / 2;
        Vector3 direction = (grappleHookHitPositionLeft - grappleHookHitPositionRight).normalized;
        float midPointOffset = 1f;
        Vector3 offsetPoint = midPoint + (direction * midPointOffset);
        //move to hook location
        characterController.Move(offsetPoint * grappleSpeed * grappleSpeedMultiplier * Time.deltaTime);

        if (GrappleRightHeld() || GrappleLeftHeld())
        {

        }
        else
        {
            if (TestJumpInput())
            {
                characterVelocityMomentum = direction * grappleSpeed * grappleJumpMultiplier;
                characterVelocityMomentum += Vector3.up * grappleJumpSpeed;
                state = State.Normal;
                ResetGravity();
                StopGrappleHook();
            }
        }
    }
    */
    private void StopGrappleHook()
    {
        //Cancel GrappleHook
        state = State.Normal;
        ResetGravity();
        hookDirection = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        grappleHookRopeTransformLeft.gameObject.SetActive(false);
        grappleHookRopeTransformRight.gameObject.SetActive(false);
        cameraFov.SetCameraFov(NORMAL_FOV);
    }

    private bool TestGrappleRightHookInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool GrappleRightHeld()
    {
        return Input.GetKey(KeyCode.E);
    }

    private bool GrappleRightUpInput()
    {
        return Input.GetKeyUp(KeyCode.E);

    }

    private bool TestGrappleLeftHookInput()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    private bool GrappleLeftHeld()
    {
        return Input.GetKey(KeyCode.Q);
    }

    private bool GrappleLeftUpInput()
    {
        return Input.GetKeyUp(KeyCode.Q);

    }

    private bool BothGrapplesUsed()
    {
        return Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E);
    }

    private bool TestJumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
