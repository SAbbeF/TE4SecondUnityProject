using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponDamage : MonoBehaviour
{
    public static int TestWeapndmg = -10;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Health.health += TestWeapndmg;
            Debug.Log(Health.health);
        }
    }
}
