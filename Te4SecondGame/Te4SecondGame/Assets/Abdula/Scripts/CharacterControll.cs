using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterControll : NetworkBehaviour
{
    #region Variable
    CharacterController characterController;

    

    [SerializeField]
    Transform playerFirstPersonCamera;

    [SerializeField]
    bool lockCursor;

    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float runSpeed;

    [SerializeField]
    float gravity;

    [SerializeField]
    private AnimationCurve jumpFallOff;

    [SerializeField]
    float jumpMultiplier;

    [SerializeField]
    KeyCode jumpKey;

    [SerializeField]
    KeyCode leftShift;

    [SerializeField]
    [Range(0.0f, 0.5f)] //range slider: works the same as Mathf.Clamp ish
    float moveSmoothTime;
    Vector2 currentDirection;
    Vector2 currentDirectionVelocity;

    [SerializeField]
    float mouseSensitivity;
    [SerializeField]
    [Range(0.0f, 0.5f)]
    float mouseSmoothTime;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    float cameraPitch;
    float velocityY;

    bool isJumping;

    #endregion

    public CharacterControll()
    {
        playerFirstPersonCamera = null;

        characterController = null;

        cameraPitch = 0.0f;

        lockCursor = true;

        walkSpeed = 3.0f;
        runSpeed = 4.5f;

        jumpMultiplier = 9.5f;

        moveSmoothTime = 0.3f;

        currentDirection = Vector2.zero;
        currentDirectionVelocity = Vector2.zero;

        mouseSensitivity = 3.5f;
        mouseSmoothTime = 0.03f;

        currentMouseDelta = Vector2.zero;
        currentMouseDeltaVelocity = Vector2.zero;

        gravity = -13.0f;
        velocityY = 0.0f;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        JumpInput();
    }

    void UpdateMouseLook()
    {
        if (isLocalPlayer)
        {
            Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            currentMouseDelta = Vector2.SmoothDamp
                (currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

            cameraPitch -= currentMouseDelta.y * mouseSensitivity;    // using -= instead of +=, inverts the Y-axis's negative and positive to align with Camera's
            cameraPitch = Mathf.Clamp(cameraPitch, -50.0f, 50.0f);

            playerFirstPersonCamera.localEulerAngles = new Vector3(1, 0, 0) * cameraPitch;
            transform.Rotate(new Vector3(0, 1, 0) * currentMouseDelta.x * mouseSensitivity);
        }
    }

    void UpdateMovement()
    {
        if (isLocalPlayer)
        {
            Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            targetDirection.Normalize();  //Normalize diagonal vectors to same length as other vectors

            currentDirection = Vector2.SmoothDamp
                (currentDirection, targetDirection, ref currentDirectionVelocity, moveSmoothTime);

            if (characterController.isGrounded)
            {
                velocityY = 0.0f;
            }
            velocityY += gravity * Time.deltaTime;

            Vector3 velocity = (transform.forward * currentDirection.y + transform.right * currentDirection.x)
                * walkSpeed + (new Vector3(0, 1, 0) * velocityY);  //Vector3.up is positive and gravity negative

            characterController.Move(velocity * Time.deltaTime);

            if (Input.GetKey(leftShift))
            {
                Vector3 runiningVelocity = (transform.forward * currentDirection.y + transform.right * currentDirection.x) 
                    * runSpeed + (new Vector3(0, 1, 0) * velocityY);
                characterController.Move(runiningVelocity * Time.deltaTime);
            }
        }
    }

    void JumpInput()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(jumpKey) && !isJumping)
            {
                isJumping = true;
                StartCoroutine(JumpEvent());
            }
        }
    }

    IEnumerator JumpEvent()
    {
        characterController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            characterController.Move(new Vector3(0, 1, 0) * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        }
        while (!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);

        characterController.slopeLimit = 45.0f;
        isJumping = false;
    }

    public override void OnStartAuthority()
    {
        playerFirstPersonCamera.gameObject.SetActive(true);
        enabled = true;
    }
}
