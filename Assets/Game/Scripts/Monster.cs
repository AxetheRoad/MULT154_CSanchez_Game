using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
   // public int maxHealth = 100;
  //  public int currentHealth;

    private Animator animEnemy;
    private bool enemyStop = false;
 
    public enum behaviour
    {
        PATROL,
        WANDER
    }

    public behaviour enemy;
  

    public List<GameObject> waypoints;
    private NavMeshAgent agent;
    private GameObject currentWP;
    private const float WP_THRESHOLD = 5.0f;
    private int currentWPIndex = -1;
  



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWP = GetNextWaypoint();
    }

    public void destroy()
    {
       
             enemyStop = true;
             //auSlime.PlayOneShot(dieSound, 1.0f);
             // animEnemy.SetBool("Die", true);
             Destroy(gameObject, 2f);
       
 
    }

    GameObject GetNextWaypoint()
    {
        currentWPIndex++;
        if (currentWPIndex == waypoints.Count)
        {
            currentWPIndex = 0;
        }
        return waypoints[currentWPIndex];
    }
    public void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    Vector3 wanderTarget = Vector3.zero;
    public void Wander()
    {
        float wanderRadius = 10;
        //float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        Debug.Log("Target before Normalize" + wanderTarget);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget; // + new Vector3(0, 0, wanderDistance);

        Seek(transform.position + targetLocal);
        Debug.Log("target Local:" + targetLocal);
        Debug.Log("Target Normalized" + wanderTarget);
    }
    void Update()
    {
        switch(enemy)
        {
            case behaviour.PATROL:
                if (Vector3.Distance(transform.position, currentWP.transform.position) < WP_THRESHOLD)
                {
                    currentWP = GetNextWaypoint();
                    agent.SetDestination(currentWP.transform.position);
                }
                break;

            case behaviour.WANDER:
                Wander();
                break;
        }

        
    }
    
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.name == "Player")

        {
           // animEnemy.SetTrigger("Attack");
            //auSlime.PlayOneShot(attackSound, .5f);
        }
    }


  
}
