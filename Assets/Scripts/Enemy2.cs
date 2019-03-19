using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    GameObject player;
    float fireRate = 1f;
    float lastFire = 0;
    bool movingDirection;


    public GameObject enemyFire2;

    void Start () {
        movingDirection = false;
    }

    void Update()
    {
        if (movingDirection)
        {
            transform.position += Vector3.forward * Time.deltaTime * 10f;
            if (transform.position.z > 10)
                movingDirection = false;
        }
        else
        {
            transform.position += Vector3.back * Time.deltaTime * 10f;
            if (transform.position.z < -10)
                movingDirection = true;
        }

        Fire();

    }

    void Fire()
    {
        if (Time.time >= fireRate + lastFire)
        {
            Instantiate(enemyFire2, this.transform.position+Vector3.right*0.7f, this.transform.rotation);
            lastFire = Time.time;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            GameManager.enemyDestryed++;
            Destroy(gameObject);
        }
    }
}
