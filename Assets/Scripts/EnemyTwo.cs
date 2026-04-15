using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 3f;
    public float frequency = 5f;
    public float magnitude = 2f;

    private Vector3 startPos; 
    public GameObject explosionPrefab;
    private GameManager gameManager;

    void Start()
    {
        //Random position spawner
        startPos = transform.position; 
    }
    void Update()
    {
        float x = Mathf.Sin(Time.time * frequency) * magnitude;
        transform.position = new Vector3(startPos.x + x, transform.position.y - speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D WhatDidIHit)
    {
        if (WhatDidIHit.tag == "Player")
        {
            WhatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        else if (WhatDidIHit.tag == "Weapons")
        {
            Destroy(WhatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}