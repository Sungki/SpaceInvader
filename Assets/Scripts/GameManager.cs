using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static int playerLive = 3;
    public static int enemyDestryed = 0;

    public GameObject playerLive2;
    public GameObject playerLive3;
    public GameObject enemy7;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;

    public GameObject obstacle;

    //    GameObject obstacleFlag;
    //    GameObject enemy2Flag;

    bool spawnFlag = false;

    float StageTime = 60f;
    public Text countText;
    int countText_int = 0;

    void Start () {
    }
	
	void Update () {
        StageTime -= Time.deltaTime;
        countText_int = (int)StageTime;
        countText.text = "Time: " + countText_int.ToString();

        if(playerLive==2)
        {
            playerLive3.SetActive(false);
        }
        else if(playerLive == 1)
        {
            playerLive2.SetActive(false);
            playerLive3.SetActive(false);
        }
        else if(playerLive == 0)
        {
            SceneManager.LoadScene("EndScene");
        }

        if (countText_int <= 0f)
        {
            SceneManager.LoadScene("EndScene");
        }

        if (countText_int % 6 == 0)
        {
            if (!spawnFlag)
            {
                spawnFlag = true;
                enemy1.SetActive(true);
                enemy2.SetActive(true);
                enemy3.SetActive(true);
                enemy4.SetActive(true);
                enemy5.SetActive(true);
                enemy6.SetActive(true);

                Instantiate(enemy7);
                Instantiate(obstacle);

                //            if (enemy2Flag == null)
                //               enemy2Flag = Instantiate(enemy7);

//                if (obstacleFlag == null)
//                obstacleFlag = Instantiate(obstacle);
            }
        }
        else
        {
            spawnFlag = false;
        }

        printEnemyDestryed();
    }

    void printEnemyDestryed()
    {
        print(enemyDestryed);

        if(enemyDestryed>=50)
        {
            SceneManager.LoadScene("SuccessScene");
        }
    }
}
