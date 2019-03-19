using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    Vector3 startPosition;
    float distance;
    float fireRange = 50f;

    void Start () {
        startPosition = this.transform.position;
    }

    void Update () {
        transform.position += Vector3.back * Time.deltaTime * 20.0f;

        distance = Vector3.Distance(this.transform.position, startPosition);

        if (distance >= fireRange)
        {
            Destroy(this.gameObject);
        }
    }
}
