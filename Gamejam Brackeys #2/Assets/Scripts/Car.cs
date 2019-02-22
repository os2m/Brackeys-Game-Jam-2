using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public GameObject[] cars;
    public float yOffset = -1;
    public Vector3 speed = new Vector3(0, 0, .3f);
    public bool destroy = true;
    public float destroytime = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (cars.Length != 0)
        {
            int random = Random.Range(0, cars.Length - 1);
            GameObject car = Instantiate(cars[random], new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z), transform.rotation);
            car.transform.parent = transform;
        }

        if (destroy)
            Destroy(gameObject, destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerController>().Respawn();
        else if (other.CompareTag("Car"))
        {
            Destroy(other.gameObject);
            Debug.Log("Car");
        }

    }
}
