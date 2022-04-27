using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OldWeaponMovement : MonoBehaviour
{

    public GameObject target;
    public float speed;
    public static int attackDamage;




    void Weapon()
    {


        if (Input.GetMouseButton(0))
        {
            attackDamage = 10;
            transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            attackDamage = 20;
            transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            attackDamage = 30;
            transform.RotateAround(target.transform.position, new Vector3(0, 0, attackDamage), speed * Time.deltaTime);
        }
    }

    void Update()
    {
        Weapon();
    }

}








