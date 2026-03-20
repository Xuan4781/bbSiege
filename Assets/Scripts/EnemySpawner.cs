using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 3f;
    public float spawnRadius = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
        randomPos.y = 1;

        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
