﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour {

	GameObject player;
    Vector3 startPosition;
    float distance;
    float fireRange = 25f;

    void Start () {
        startPosition = this.transform.position;
    }

	void Update () {
   		transform.position += Vector3.forward * Time.deltaTime * 15.0f;
        distance = Vector3.Distance(this.transform.position, startPosition);

        if (distance >= fireRange)
        {
            Destroy(this.gameObject);
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
