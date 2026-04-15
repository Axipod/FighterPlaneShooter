using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject cloudPrefab;
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;

    public float spawnRate = 2f;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;

        CreateSky();

        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 1.5f, 3);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {

            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }
    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * .9f, verticalScreenSize, 0), Quaternion.identity);
    }
    void CreateEnemyTwo()
    {
      /*  float randomX = Random.Range(-8f, 8f);

        GameObject enemyToSpawn;

 
        if (Random.value > 0.7f)
            enemyToSpawn = enemyTwoPrefab; 
        else
            enemyToSpawn = enemyOnePrefab;
      */
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * .9f, verticalScreenSize, 0), Quaternion.identity);

    }


public void ChangeLivesText(int currentLives)
    {
        livesText.text = "lives " + currentLives;

    }
}