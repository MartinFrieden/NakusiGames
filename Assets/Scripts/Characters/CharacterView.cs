using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent _agent = null;
    float _remainingDistance;

    [Inject]
    public CharacterFacade Facade
    {
        get; set;
    }
    public float ReminingDistance
    {
        get { return _agent.remainingDistance; }
    }
    public NavMeshAgent NavMeshAgent
    {
        get { return _agent; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public void MoveCharacter(Vector3 target)
    {
        _agent.SetDestination(target);
    }
}
