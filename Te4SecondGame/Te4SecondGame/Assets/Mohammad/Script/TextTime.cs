using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTime : MonoBehaviour
{
    //public Vector3 RandomizeIntensity = new Vector3(0-0.0001f, 0, 0);

    void Start()
    {
        Destroy(gameObject, 1f);
        //transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
        //Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
        //Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
    }

}
