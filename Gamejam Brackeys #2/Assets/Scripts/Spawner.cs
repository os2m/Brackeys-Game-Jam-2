using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public float minSpawnTime = 1;
    public float maxSpawnTime = 4;
    private float currentTime;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = minSpawnTime;
        time = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= time)
        {
            currentTime = minSpawnTime;
            Instantiate(car, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            time = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
