using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffect : MonoBehaviour
{
    public TextMeshPro damageText;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            damageText.text = TestWeaponDamage.TestWeapndmg.ToString();
            Instantiate(damageText, transform.position, transform.rotation);
            //Instantiate(damageText, new Vector3(transform.position.x-0.4f, transform.position.y, transform.position.z), transform.rotation);
        }
    }


}
