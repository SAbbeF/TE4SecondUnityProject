using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestHealth : MonoBehaviour
{
    public static int health = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("weapon"))
        {
            Debug.Log("Weapon dmg");
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
        

}
