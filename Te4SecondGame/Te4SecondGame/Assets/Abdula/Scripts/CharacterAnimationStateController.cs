using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationStateController : MonoBehaviour
{
    Animator animator;
    //bool isWalking;
    //bool forwardPressed;

    public CharacterAnimationStateController()
    {

    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        #region old if condition
        //if (Input.GetKeyDown("w"))
        //{
        //    animator.SetBool("isWalking", true);
        //}

        //if (Input.GetKeyUp("w"))
        //{
        //    animator.SetBool("isWalking", false);
        //}
        #endregion

        animator.SetBool("isWalking", Input.GetKey("w"));
        animator.SetBool("isRunning", (Input.GetKey("left shift") && Input.GetKey("w")));
        animator.SetBool("isAttacking", Input.GetKey("mouse 0"));
    }
}
