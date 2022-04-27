using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStone : MonoBehaviour
{
    public GameObject stone;
    public void Stone()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            Instantiate(stone, new Vector3(transform.position.x + 3, transform.position.y+3, transform.position.z), transform.rotation);
        }
    }
    private void Update()
    {
        Stone();
    }
}
