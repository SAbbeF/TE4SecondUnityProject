using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MouseControl : NetworkBehaviour
{
    CharacterController characterController;

    [SerializeField]
    Transform playerFirstPersonCamera;

    [SerializeField]
    bool lockCursor;

    //[SerializeField]
    //float walkSpeed;

    //[SerializeField]
    //float gravity;

    //[SerializeField] [Range(0.0f, 0.5f)] //range slider: works the same as Mathf.Clamp ish
    //float moveSmoothTime;
    //Vector2 currentDirection;
    //Vector2 currentDirectionVelocity;

    [SerializeField]
    float mouseSensitivity;
    [SerializeField] [Range(0.0f, 0.5f)] 
    float mouseSmoothTime;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    float cameraPitch;
    //float velocityY;


    public MouseControl()
    {
        playerFirstPersonCamera = null;

        characterController = null;

        cameraPitch = 0.0f;

        lockCursor = true;

        //walkSpeed = 3.0f;

        //moveSmoothTime = 0.3f;

        //currentDirection = Vector2.zero;
        //currentDirectionVelocity = Vector2.zero;

        mouseSensitivity = 3.5f;
        mouseSmoothTime = 0.03f;

        currentMouseDelta = Vector2.zero;
        currentMouseDeltaVelocity = Vector2.zero;

        //gravity = -13.0f;
        //velocityY = 0.0f;

        //mouseDelta = new Vector2(Input.GetAxis("Mouse X"),
        //Input.GetAxis("Mouse Y")); Unity does not allow to call GetAxis outside Start or Awake seperately,
        //it works if you define and call it in one method though
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
        //UpdateMovement();
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;    // using -= instead of +=, inverts the Y-axis's negative and positive to align with Camera's
        cameraPitch = Mathf.Clamp(cameraPitch, -50.0f, 50.0f);

        playerFirstPersonCamera.localEulerAngles = new Vector3(1, 0, 0) * cameraPitch;
        transform.Rotate(new Vector3(0, 1, 0) * currentMouseDelta.x * mouseSensitivity);
    }

    //void UpdateMovement()
    //{
    //    Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    //    targetDirection.Normalize();  //Normalize diagonal vectors to same length as other vectors

    //    currentDirection = Vector2.SmoothDamp(currentDirection, targetDirection, ref currentDirectionVelocity, moveSmoothTime);

    //    if (characterController.isGrounded)
    //    {
    //        velocityY = 0.0f;
    //    }
    //    velocityY += gravity * Time.deltaTime;

    //    Vector3 velocity = (transform.forward * currentDirection.y + transform.right * currentDirection.x) * walkSpeed + (new Vector3(0, 1, 0) * velocityY);  //Vector3.up is positive and gravity negative

    //    characterController.Move(velocity * Time.deltaTime);
    //}
}
