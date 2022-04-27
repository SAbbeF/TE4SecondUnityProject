using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : MonoBehaviour
{
    public static int Aihleath = 100;


    void Update()
    {
        if (Aihleath <= 0)
        {
            Destroy(gameObject);
            GetComponent<Effect>().Death();
        }
    }
}
