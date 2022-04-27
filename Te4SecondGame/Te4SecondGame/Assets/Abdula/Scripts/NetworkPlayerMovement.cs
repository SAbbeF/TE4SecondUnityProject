using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private float playerSpeed;

    //[SerializeField]
    //private float playerRotationSpeed;

    [SerializeField]
    KeyCode towardRight;

    [SerializeField]
    KeyCode towardLeft;

    [SerializeField]
    KeyCode towardUp;

    [SerializeField]
    KeyCode towardDown;

    //[SerializeField]
    //KeyCode swingRight;

    //[SerializeField]
    //KeyCode swingLeft;

    [SerializeField]
    KeyCode Reset;

    public NetworkPlayerMovement()
    {
        playerSpeed = 1.0f;
        //playerRotationSpeed = 720f;
    }

    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKey(towardRight))
            {
                transform.position += playerSpeed * Vector3.right;
            }

            if (Input.GetKey(towardLeft))
            {
                transform.position += playerSpeed * Vector3.left;
            }

            if (Input.GetKey(towardUp))
            {
                transform.position += playerSpeed * Vector3.forward;
            }

            if (Input.GetKey(towardDown))
            {
                transform.position += playerSpeed * Vector3.back;
            }

            if (Input.GetKey(Reset))
            {
                transform.position = new Vector3(0, 1, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
}
