using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public GameObject cloudPrefab;
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject gameOverMenu;
    public GameObject powerupPrefab;
    

    public AudioClip powerUpSound;
    public AudioClip powerDownSound;

    public GameObject audioPlayer;

    public float spawnRate = 2f;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    private bool gameOver;
    public TextMeshProUGUI powerupText;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        gameOver = false;
        score = 0;




        CreateSky();

        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 1.5f, 3);
        StartCoroutine(SpawnPowerup());
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
    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void CreatePowerup()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-horizontalScreenSize * .8f, horizontalScreenSize * .8f), Random.Range(-verticalScreenSize * .8f, verticalScreenSize * .8f), 0), Quaternion.identity);
    }
    IEnumerator SpawnPowerup()
    {
        float spawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(spawnTime);
        CreatePowerup();
        StartCoroutine(SpawnPowerup());
    }
    public void ManagePowerupText(int powerupType)
    {
        switch (powerupType)
        {
            case 1:
                powerupText.text = "Speed!";
                break;
            case 2:
                powerupText.text = "Double Weapon!";
                break;
            case 3:
                powerupText.text = "Triple Weapon!";
                break;
            case 4:
                powerupText.text = "Shield!";
                break;
            default:
                powerupText.text = "No powerups yet!";
                break;
        }
    }
    public void PlaySound(int whichSound)
    {
        switch (whichSound)
        {
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerUpSound);
                break;
            case 2:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerDownSound);
                break;
        }
    }
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        //game over to be true 
        gameOver = true;
    }
    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "lives " + currentLives;

    }

}