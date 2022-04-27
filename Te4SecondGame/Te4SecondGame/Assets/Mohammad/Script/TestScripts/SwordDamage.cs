using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SwordDamage : NetworkBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Health.health -= SwordMovement.attackDamage;
            Debug.Log(Health.health);
        }
    }
}