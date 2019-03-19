using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    public static float speed = 8.0f;
    Transform bullet2;

	void Start () {
    }

	void Update () {
		transform.position += new Vector3 (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);


        if (transform.position.x >= 15f)
            transform.position = new Vector3(15f, transform.position.y, transform.position.z);

        if (transform.position.x <= -15f)
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);

        if (transform.position.z >= 10f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 10f);

        if (transform.position.z <= -10f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);


        if (Input.GetKeyDown(KeyCode.Space)) 
		{
//			Instantiate (bulletPrefab);
            Instantiate(bulletPrefab, transform.position+Vector3.forward*1.1f, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(bullet2Prefab,transform.position+new Vector3(-2,0,0), Quaternion.identity);
            Instantiate(bullet2Prefab, transform.position+new Vector3(+2, 0, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
        {
            GameManager.playerLive--;
            if (GameManager.playerLive <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(0, 0, -10);
            }
        }
    }
}
