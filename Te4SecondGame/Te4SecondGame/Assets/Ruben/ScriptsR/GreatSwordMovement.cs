using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class GreatSwordMovement : NetworkBehaviour
{
    Animator animate;
    public static bool greatSwordLight;
    public bool greatSwordParry;
    public bool greatSwordHeavy;
    public bool greatSwordSpecial;
    public static int greatSwordDamage;


    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        greatSwordLight = animate.GetBool("greatSwordLight");
        greatSwordHeavy = animate.GetBool("greatSwordHeavy");
        greatSwordParry = animate.GetBool("greatSwordParry");
        greatSwordSpecial = animate.GetBool("greatSwordSpecial");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && greatSwordLight == false)
        {
            animate.SetBool("greatSwordLight", true);
            greatSwordDamage = -20;
            Debug.Log(greatSwordDamage);

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animate.SetBool("greatSwordLight", false);
        }

        if (Input.GetButtonDown("Fire2") && greatSwordHeavy == false)
        {
            animate.SetBool("greatSwordHeavy", true);
            greatSwordDamage = -25;
            Debug.Log(greatSwordDamage);

        }
        else if (Input.GetButtonUp("Fire2"))
        {
            animate.SetBool("greatSwordHeavy", false);

        }

        if (Input.GetKeyDown(KeyCode.Mouse2) && greatSwordSpecial == false)
        {
            animate.SetBool("greatSwordSpecial", true);
            greatSwordDamage = -15;



        }
        else if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            animate.SetBool("greatSwordSpecial", false);

        }

        if (Input.GetKeyDown(KeyCode.Q) && greatSwordParry == false)
        {
            animate.SetBool("greatSwordParry", true);
            greatSwordDamage = 0;
            Debug.Log(greatSwordDamage);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        { 
            animate.SetBool("greatSwordParry", false);
        }
    }
}

