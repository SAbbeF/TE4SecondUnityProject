using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSwordS : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyAI"))
        {
            AiHealth.Aihleath += GreatSwordMovement.greatSwordDamage;
            Debug.Log(AiHealth.Aihleath);
        }
        //public void OnTriggerStay(Collider other)
        //    {
        //        if (other.gameObject.tag == "EnemyAI") {GreatSwordMovement.greatSwordLight = true; }
        //        else if (other.gameObject.tag != "EnemyAI") { GreatSwordMovement.greatSwordLight = false; }
        //    }
    }

}