using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject[] enemyPrefabs;
    public float autoSpawnInterval = 2f; // Time in seconds between auto spawns
    public float autoSpawnDuration = 10f; // Time in seconds to keep auto spawning

    private float autoSpawnTimer;
    private float autoSpawnElapsed;
    private bool autoSpawningActive = true;

    void Start()
    {
        autoSpawnTimer = autoSpawnInterval;
        autoSpawnElapsed = 0f;
        autoSpawningActive = true;
    }

    void Update()
    {
        // Manual spawn on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            SpawnRandomEnemy();
        }

        // Automatic spawn by computer
        if (autoSpawningActive)
        {
            autoSpawnElapsed += Time.deltaTime;
            autoSpawnTimer -= Time.deltaTime;
            if (autoSpawnTimer <= 0f)
            {
                SpawnRandomEnemy();
                autoSpawnTimer = autoSpawnInterval;
            }
            if (autoSpawnElapsed >= autoSpawnDuration)
            {
                autoSpawningActive = false;
            }
        }
    }

    void SpawnRandomEnemy()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
