using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public enum behaviour
    {
        PATROL,
        WANDER
    }
    public behaviour enemyB;
  

    public List<GameObject> waypoints;
    private NavMeshAgent agent;
    private GameObject currentWP;
    private const float WP_THRESHOLD = 3.0f;
    private int currentWPIndex = -1;
    public GameObject attack;

    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWP = GetNextWaypoint();
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
        float wanderRadius = 3;
        float wanderDistance = 3;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);

        Seek(transform.position + targetLocal);
    }
    void Update()
    {
        switch(enemyB)
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
}
