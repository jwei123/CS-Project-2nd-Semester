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
    void Update()
    {
        if(running == false)
        {
            nav.SetDestination(new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y, transform.position.z + Random.Range(-2f, 2f)));
            running = true;
        }
        if(nav.isStopped == true)
        {
            running = false;
        }
    }
}
