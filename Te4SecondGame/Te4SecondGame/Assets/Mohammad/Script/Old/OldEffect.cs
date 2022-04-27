using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldEffect : MonoBehaviour
{
    public GameObject blood;
    public GameObject death;
    public TextMeshPro damageText;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("weapon"))
        //if (collision.collider.tag == "weapon")
        {
            Instantiate(blood, transform.position, transform.rotation);
            damageText.text = SwordMovement.attackDamage.ToString();
            Instantiate(damageText, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
        }
        if (TestHealth.health <= 0)
        {
            Instantiate(death, transform.position, transform.rotation);
        }
    }
}
