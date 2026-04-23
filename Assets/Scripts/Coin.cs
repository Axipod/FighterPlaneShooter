using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 5;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}