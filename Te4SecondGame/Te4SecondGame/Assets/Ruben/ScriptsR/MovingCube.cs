using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float xAxis;
    public float zAxis;
    public float speed = 10f;
    public CharacterController controller;

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;

        controller.Move(move * speed * Time.deltaTime);


        
    }
}
