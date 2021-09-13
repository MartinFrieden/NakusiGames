using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealthBarDirection : MonoBehaviour
{
    Camera _target;

    [Inject]
    public void Construct(Camera camera)
    {
        _target = camera;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target.transform.position);
    }
}
