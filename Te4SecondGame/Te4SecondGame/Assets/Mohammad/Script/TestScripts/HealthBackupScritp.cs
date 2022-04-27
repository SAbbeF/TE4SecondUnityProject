using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HealthBackupScript : NetworkBehaviour
{
    public static int health = 100;
    private int dmg;
    //public Effect instance;
    //public SwordMovement swordMovement;

    void OnCollisionEnter(Collision collision)
    {
        if (isLocalPlayer)
        {
            if (collision.gameObject.tag.Equals("weapon"))
            //if (collision.collider.tag == "weapon")
            {
                dmg = SwordMovement.attackDamage;

                //if (isLocalPlayer)
                //{
                //    if (Input.GetKey(KeyCode.E))
                //    {
                //        dmg = 0;
                //    }
                //    else
                //    {
                health -= dmg;
                //health -= SwordMovement.attackDamage;
                Debug.Log(health);
                //transform.position = swordMovement.StartPosition();
                //originalPos = gameObject.transform.position;
                //gameObject.transform.position = SwordMovement.StartPoint;
                //}
            }
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
