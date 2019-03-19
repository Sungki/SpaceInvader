using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    bool movingDirection;
    float fireRate = 1f;
    float lastFire = 0;

    public GameObject enemyFire;
    public GameObject item;

    void Start()
    {
        movingDirection = false;
    }

    void Update()
    {
        if (movingDirection)
        {
            transform.position += Vector3.right * Time.deltaTime * 10f;
            if (transform.position.x > 17)
                movingDirection = false;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * 10f;
            if (transform.position.x < -12)
                movingDirection = true;
        }

        Fire();

    }

    void Fire()
    {
        if (Time.time >= fireRate + lastFire)
        {
            Instantiate(enemyFire, this.transform.position + Vector3.back * 0.7f, this.transform.rotation);
            lastFire = Time.time;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            GameManager.enemyDestryed++;
            gameObject.SetActive(false);

            if (GameManager.enemyDestryed == 25)
            {
                Instantiate(item, this.transform.position, Quaternion.identity);
            }
        }
    }
}
