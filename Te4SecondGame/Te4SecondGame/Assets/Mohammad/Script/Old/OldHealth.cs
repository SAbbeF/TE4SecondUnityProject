using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OldHealth : MonoBehaviour
{
    public static int health = 100;

    void OnTriggerEnter(Collider other)
    {
        //if (other.collis.tag == "weapon")
        //{
        //    if (collision.collider.tag == "weapon")

        //}
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
