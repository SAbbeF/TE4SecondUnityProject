using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Health.health -= SwordMovement.attackDamage;
        }
        
    }
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
