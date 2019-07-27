using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cam;
    public float speed = 0.1f;

    void Update()
    {
        var direction = cam.transform.forward;
        direction.y = -1f;

        var target = cam.position + direction * 1.0f;

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }
}
