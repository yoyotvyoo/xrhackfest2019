using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject redCar;
    public GameObject whiteCar;
    public GameObject yellowCar;
    public GameObject blackCar;
    public Transform start;
    public Transform end;

    void Start()
    {
        StartCoroutine(CarSpawnCoroutine());
        // InvokeRepeating("LaunchCar", 2.0f, 5.0f);
    }

    private IEnumerator CarSpawnCoroutine()
    {
        yield return new WaitForSeconds(3.0f);

        var redCar = GameObject.Instantiate(this.redCar, start.position, start.rotation);
        redCar.GetComponent<MoveTowards>().destination = end;

        yield return new WaitForSeconds(5.0f);

        var whiteCar = GameObject.Instantiate(this.whiteCar, start.position, start.rotation);
        whiteCar.GetComponent<MoveTowards>().destination = end;

        yield return new WaitForSeconds(5.0f);

        var yellowCar = GameObject.Instantiate(this.yellowCar, start.position, start.rotation);
        yellowCar.GetComponent<MoveTowards>().destination = end;

        yield return new WaitForSeconds(5.0f);

        var blackCar = GameObject.Instantiate(this.blackCar, start.position, start.rotation);
        blackCar.GetComponent<MoveTowards>().destination = end;
    }
}
