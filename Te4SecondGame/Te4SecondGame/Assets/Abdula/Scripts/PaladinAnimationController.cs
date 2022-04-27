using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PaladinAnimationController : NetworkBehaviour
{
    #region Variables
    Animator animator;
    float velocityX;
    float velocityZ;

    float acceleration;
    float deceleration;

    float maximumWalkVelocity;
    float maximumRunVelocity;

    int velocityZHash;
    int velocityXHash;

    #endregion

    public PaladinAnimationController()
    {
        velocityX = 0.0f;
        velocityZ = 0.0f;

        acceleration = 3.5f;
        deceleration = 4.5f;

        maximumWalkVelocity = 0.5f;
        maximumRunVelocity = 1.0f;
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        velocityZHash = Animator.StringToHash("velocity Z");
        velocityXHash = Animator.StringToHash("velocity X");
    }


    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        if (isLocalPlayer)
        {

            if (forwardPressed && velocityZ < currentMaxVelocity)
            {
                velocityZ += Time.deltaTime * acceleration;
            }

            if (backPressed && velocityZ > -currentMaxVelocity)
            {
                velocityZ -= Time.deltaTime * acceleration;
            }



            if (leftPressed && velocityX > -currentMaxVelocity)
            {
                velocityX -= Time.deltaTime * acceleration;
            }

            if (rightPressed && velocityX < currentMaxVelocity)
            {
                velocityX += Time.deltaTime * acceleration;
            }



            if (!forwardPressed && velocityZ > 0.0f)
            {
                velocityZ -= Time.deltaTime * deceleration;
            }

            if (!backPressed && velocityZ < 0.0f)
            {
                velocityZ += Time.deltaTime * deceleration;
            }



            if (!leftPressed && velocityX < 0.0f)
            {
                velocityX += Time.deltaTime * deceleration;
            }

            if (!rightPressed && velocityX > 0.0f)
            {
                velocityX -= Time.deltaTime * deceleration;
            }
        }
    }

    void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        if (isLocalPlayer)
        {

            if (!forwardPressed && !backPressed && velocityZ != 0.0f && (velocityZ > -0.5f && velocityZ < 0.5f))
            {
                velocityZ = 0.0f;
            }

            if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.5f && velocityX < 0.5f))
            {
                velocityX = 0.0f;
            }



            if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
            {
                velocityZ = currentMaxVelocity;
            }

            else if (forwardPressed && velocityZ > currentMaxVelocity)
            {
                velocityZ -= Time.deltaTime * deceleration;
                if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.5f))
                {
                    velocityZ = currentMaxVelocity;
                }
            }

            else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.5f))
            {
                velocityZ = currentMaxVelocity;
            }



            if (backPressed && runPressed && velocityZ < -currentMaxVelocity)
            {
                velocityZ = -currentMaxVelocity;
            }

            else if (backPressed && velocityZ < -currentMaxVelocity)
            {
                velocityZ += Time.deltaTime * deceleration;
                if (velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.5f))
                {
                    velocityZ = -currentMaxVelocity;
                }
            }

            else if (backPressed && velocityZ > -currentMaxVelocity && velocityZ < (-currentMaxVelocity + 0.5f))
            {
                velocityZ = -currentMaxVelocity;
            }



            if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
            {
                velocityX = -currentMaxVelocity;
            }

            else if (leftPressed && velocityX < -currentMaxVelocity)
            {
                velocityX += Time.deltaTime * deceleration;
                if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.5f))
                {
                    velocityX = -currentMaxVelocity;
                }
            }

            else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.5f))
            {
                velocityX = -currentMaxVelocity;
            }



            if (rightPressed && rightPressed && velocityX > currentMaxVelocity)
            {
                velocityX = currentMaxVelocity;
            }

            else if (rightPressed && velocityX > currentMaxVelocity)
            {
                velocityX -= Time.deltaTime * deceleration;
                if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.5f))
                {
                    velocityX = currentMaxVelocity;
                }
            }

            else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.5f))
            {
                velocityX = currentMaxVelocity;
            }
        }
    }
    void Update()
    {
        if (isLocalPlayer)
        {
            bool forwardPressed = Input.GetKey(KeyCode.W);
            bool leftPressed = Input.GetKey(KeyCode.A);
            bool rightPressed = Input.GetKey(KeyCode.D);
            bool backPressed = Input.GetKey(KeyCode.S);
            bool runPressed = Input.GetKey(KeyCode.LeftShift);

            float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

            ChangeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
            LockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);

            animator.SetFloat(velocityZHash, velocityZ);
            animator.SetFloat(velocityXHash, velocityX);

            animator.SetBool("isJumping", Input.GetKey(KeyCode.Space));
        }
    }
}
