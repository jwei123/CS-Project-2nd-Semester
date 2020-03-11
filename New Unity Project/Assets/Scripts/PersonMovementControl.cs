using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonMovementControl : MonoBehaviour
{
    public NavMeshAgent nav;
    public int radiusMovementRange;
    private Vector3 spawnPosition;
    private bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // MAKE Sure that you set a radiusmovement range for the spawning of the people!!
        float dist = nav.remainingDistance;
        if(running == false)
        {

            Vector3 newDest = new Vector3(transform.localPosition.x + Random.Range((-1 * radiusMovementRange), radiusMovementRange), transform.localPosition.y, transform.localPosition.z + Random.Range((-1*radiusMovementRange), radiusMovementRange));
            if(Mathf.Abs(newDest.x )- Mathf.Abs(spawnPosition.x)  >= radiusMovementRange)
            {
                if(newDest.x    >= 0)
                {
                    newDest.x = spawnPosition.x + radiusMovementRange;
                }
                else
                {
                    newDest.x = -1 * (spawnPosition.x + radiusMovementRange);
                }
                
            }
            if (Mathf.Abs(newDest.z) - Mathf.Abs(spawnPosition.z) >= radiusMovementRange)
            {
                if (newDest.z >= 0)
                {
                    newDest.z = spawnPosition.z + radiusMovementRange;
                }
                else
                {
                    newDest.z = -1 * (spawnPosition.z + radiusMovementRange);
                }

            }
            nav.SetDestination(newDest);

            running = true;
        }
        if(dist == 0 || nav.velocity.sqrMagnitude == 0f )
        {
            running = false;
        }
    }

}
