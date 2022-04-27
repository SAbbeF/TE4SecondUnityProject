using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkMovement : MonoBehaviour
{
    Animator animate;
    public bool parry;
    public bool attacking;
    public bool attackingH;
    public bool attackingSp;
    public bool attackingSH;
    public static int weaponDamage;



    // Start is called before the first frame update
    void Start()
    {

        animate = GetComponent<Animator>();
        parry = animate.GetBool("parry");
        attacking = animate.GetBool("attacking");
        attackingH = animate.GetBool("attackingH");
        attackingSp = animate.GetBool("attackingSp");
        attackingSH = animate.GetBool("attackingSH");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && attacking == false)
        {
            animate.SetBool("attacking", true);
            weaponDamage = -5;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animate.SetBool("attacking", false);
        }


        if (Input.GetButtonDown("Fire2") && attacking == false)
        {
            animate.SetBool("attackingSp", true);
            weaponDamage = -20;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            animate.SetBool("attackingSp", false);

        }

        if (Input.GetKeyDown(KeyCode.Mouse2) && attacking == false)
        {
            animate.SetBool("attackingH", true);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            animate.SetBool("attackingH", false);
            weaponDamage = -5;

        }

        if (Input.GetKeyDown(KeyCode.Q) && parry == false)
        {
            animate.SetBool("parry", true);
            weaponDamage = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            animate.SetBool("parry", false);
        }
    }
}