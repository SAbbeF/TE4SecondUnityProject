using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyAI"))
        {
            AiHealth.Aihleath += BonkMovement.weaponDamage;
            Debug.Log(AiHealth.Aihleath);
        }
        if (other.gameObject.tag.Equals("EnemyAI"))
        {
            AiHealth.Aihleath += SwordAndShieldMovement.SAO;
            Debug.Log(AiHealth.Aihleath);
        }
        if (other.gameObject.tag.Equals("EnemyAI"))
        {
            AiHealth.Aihleath += AxeMovement.axeDmg;
            Debug.Log(AiHealth.Aihleath);
        }
    }
}