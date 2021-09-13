using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public List<BaseBomb> bombs;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 2f);
    }

    void Spawn()
    {
        Instantiate(bombs[Random.Range(0, bombs.Count)],
            new Vector3(Random.Range(-10,10), 10, Random.Range(-10,10)), 
            Quaternion.identity);
        Invoke("Spawn", Random.Range(2, 5));
    }
}
