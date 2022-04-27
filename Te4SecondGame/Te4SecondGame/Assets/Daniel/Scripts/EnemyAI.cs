using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;
    public float radius = 5f;
    GameObject closest ;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        FindClosestEnemy();
        //Vector3 direction = transform.DirectionTo(target.position);
        //target = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(closest.transform.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.stoppingDistance = 3f;
            if (distance <= agent.stoppingDistance)
            {

                FaceTarget();
                animator.SetFloat("Speed", agent.velocity.magnitude);

            }
            //animator.SetBool("Attack", false);
         
         
                agent.SetDestination(closest.transform.position);
                animator.SetFloat("Speed", agent.velocity.magnitude);

        


            //LookToward(transform.position, distance);
            //Vector3 movement = transform.forward * Time.deltaTime * 1f;
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
        //animator.SetBool("Attack", false);
    }

    void FaceTarget()
    {
        Vector3 direction = (closest.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        animator.SetFloat("Speed", 0f);
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Player");
        closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
