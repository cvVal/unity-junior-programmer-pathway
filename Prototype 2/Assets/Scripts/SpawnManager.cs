using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10f;
    private float spawnPosZ = 30f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        // Randomly select an animal prefab from the array
        Vector3 spawnPos = new(
            Random.Range(-spawnRangeX, spawnRangeX),
            0,
            spawnPosZ
        );
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(
            animalPrefabs[randomIndex],
            spawnPos,
            animalPrefabs[randomIndex].transform.rotation
        );
    }
}
