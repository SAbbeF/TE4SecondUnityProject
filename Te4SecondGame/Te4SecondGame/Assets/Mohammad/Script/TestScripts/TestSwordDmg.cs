using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwordDmg : MonoBehaviour
{
    public GameObject stone;
    public void SummoningStone()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(stone, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), transform.rotation);
        }
    }


}
//GetComponent<TestSwordDmg>().SummoningStone();