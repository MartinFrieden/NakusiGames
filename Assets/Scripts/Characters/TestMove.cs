using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{
    [SerializeField] NavMeshSurface surface;
    [SerializeField] NavMeshAgent agent;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = surface.size;
        Debug.Log(target);
        agent.SetDestination(new Vector3(0,0,10));

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= 0.5f)
        {
            Debug.Log("Stop");
            agent.SetDestination(new Vector3(Random.Range(-10,10), 0, Random.Range(-10, 10)));
        }
    }
}
