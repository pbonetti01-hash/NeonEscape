using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject crystalPrefab;

    [Header("Spawn Timing")]
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.2f;

    [Header("Speed")]
    public float minSpeed = 8f;
    public float maxSpeed = 12f;

    [Header("Lifetime")]
    public float crystalLifetime = 5f;

    [Header("Lanes")]
    public float laneDistance = 2.5f;

    private float timer;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (CrystalManager.Instance.ReachedGoal())
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnCrystal();
            ResetTimer();
        }
    }

    void SpawnCrystal()
    {
        int lane = Random.Range(-1, 2);

        Vector3 spawnPos = new Vector3(
            lane * laneDistance,
            -1f, 
            transform.position.z
        );

        GameObject obj = Instantiate(crystalPrefab, spawnPos, Quaternion.identity);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        obj.GetComponent<Crystal>().Init(randomSpeed, crystalLifetime);
    }

    void ResetTimer()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }
}