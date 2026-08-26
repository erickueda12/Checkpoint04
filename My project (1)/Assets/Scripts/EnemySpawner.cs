using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] float spawnInterval = 2f;

    float spawnTimer;

    private void Update()
    {
        if (GameManager.Instance.machine.CurrentState != GameManager.Instance.playingState)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(
            enemyPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}