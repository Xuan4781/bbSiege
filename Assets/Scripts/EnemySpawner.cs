using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;
    public float spawnRadius = 15f;

    bool spawning = false;

    public void BeginSpawning()
    {
        if (spawning) return;
        spawning = true;

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector2 random = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPos = new Vector3(random.x, 1, random.y);

        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}