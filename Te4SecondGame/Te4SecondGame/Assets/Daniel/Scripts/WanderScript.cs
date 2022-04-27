using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour
{
    public float velocity;
    public float rotatingSpeed;

    private bool isWalking ;
    private bool isRotatingRight;
    private bool isWandering;
    private bool isRotatingLeft;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        isRotatingLeft = false;
        isRotatingRight = false;
        isWandering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingLeft == true)
        {
            transform.Rotate(transform.up *Time.deltaTime* rotatingSpeed);
        }
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * - rotatingSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward  *Time.deltaTime * velocity;
        }
    }


    IEnumerator Wander()
    {
        int rotateTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLeftOrRight = Random.Range(0, 3);
        int walkWait = Random.Range(1, 4);
        int WalkTime = Random.Range(1, 5);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(WalkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if(rotateLeftOrRight == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotateTime);
            isRotatingLeft = false;
        }
        if (rotateLeftOrRight == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotateTime);
            isRotatingRight = false;
        }
        isWandering = false;

    }
}
