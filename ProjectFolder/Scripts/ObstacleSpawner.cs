using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    [Header("Spawn Timing")]
    public float minSpawnTime = 0.8f;
    public float maxSpawnTime = 1.5f;

    [Header("Speed")]
    public float minSpeed = 8f;
    public float maxSpeed = 14f;

    [Header("Lifetime")]
    public float obstacleLifetime = 5f;

    [Header("Lanes")]
    public float laneDistance = 2.5f;

    private float timer;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObstacle();
            ResetTimer();
        }
    }

    void SpawnObstacle()
    {
        // Escolhe lane aleatória (-1, 0, 1)
        int lane = Random.Range(-1, 2);

        Vector3 spawnPos = new Vector3(
            lane * laneDistance,
            0,
            transform.position.z
        );

        GameObject obj = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        obj.GetComponent<Obstacle>().Init(randomSpeed, obstacleLifetime);
    }

    void ResetTimer()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }
}