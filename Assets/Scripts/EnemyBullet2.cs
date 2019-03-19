using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour {

    Vector3 startPosition;
    float distance;
    float fireRange = 30f;

    void Start () {
        startPosition = this.transform.position;
    }


    void Update () {
   		transform.position += Vector3.right * Time.deltaTime * 15.0f;

        distance = Vector3.Distance(this.transform.position, startPosition);

        if (distance >= fireRange)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
