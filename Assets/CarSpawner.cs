using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] cars;
    public Transform start;
    public Transform end;

    void Start()
    {
        InvokeRepeating("LaunchCar", 2.0f, 5.0f);
    }

    void LaunchCar()
    {
        var index = Random.Range(0, cars.Length);

        var go = GameObject.Instantiate(cars[index], start.position, start.rotation);
        go.GetComponent<MoveTowards>().destination = end;
    }
}
