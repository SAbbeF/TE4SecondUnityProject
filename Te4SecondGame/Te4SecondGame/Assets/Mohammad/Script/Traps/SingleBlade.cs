//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SingleBlade : MonoBehaviour
//{
//    public GameObject SingleBladeActivating;

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            ActivateTrap();
//        }
//    }
//    void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            DeActivateTrap();
//        }
//    }
//    public void ActivateTrap()
//    {
//        SingleBladeActivating.SetActive(true);
//    }
//    public void DeActivateTrap()
//    {
//        SingleBladeActivating.SetActive(false);
//    }
//}
