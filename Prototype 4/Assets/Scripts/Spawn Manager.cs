using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    public int enemyCount;

    private readonly float spawnRange = 9f;
    private int waveNumber = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemiesInWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0 && waveNumber < enemyPrefabs.Length)
        {
            waveNumber++;
            // If no enemies are left, spawn new ones
            SpawnEnemiesInWave(waveNumber);
            SpawnPowerup(waveNumber);
        }
    }

    void SpawnEnemiesInWave(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPrefabs[waveNumber - 1], GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    void SpawnPowerup(int waveNumber)
    {
        if (waveNumber % 2 == 0) // Spawn a powerup every second wave
        {
            Instantiate(powerupPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);
        return new Vector3(x, 0, z);
    }
}
