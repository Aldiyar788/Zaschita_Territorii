using UnityEngine;

public class Spawner_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] humansPrefabs;
    [SerializeField] private float spawnRangeX = 13.0f;
    [SerializeField] private float spawnPosZ = 20.0f;
    [SerializeField] private float startDelay = 2.0f;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnIntervalDecrease = 0.1f;
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private int initialSpawnCount = 1;
    [SerializeField] private int maxSpawnInterval = 8;
    [SerializeField] private float spawnCountIncreaseInterval = 300f;


    private float currentSpawnInterval;
    private int currentSpawnCount;

    void Start()
    {
        currentSpawnInterval = spawnInterval;
        currentSpawnCount = initialSpawnCount;

        InvokeRepeating("SpawnRandoInterval", startDelay, spawnInterval);
        InvokeRepeating("IncreaseSpawnRate", startDelay, 5.0f); // Ќачинаем уменьшать интервал через 5 секунд, повтор€ем каждые 5 секунд
        InvokeRepeating("IncreaseSpawnCount", startDelay, spawnCountIncreaseInterval);
    }

    void SpawnRandoInterval()
    {
        for (int i = 0; i < currentSpawnCount; i++)
        {
            int humansIndex = Random.Range(0, humansPrefabs.Length); //рандомный индекс префаба человека
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); //рандомна€ позици€ спавна по X
            Instantiate(humansPrefabs[humansIndex], //префаб человека
                spawnPos, //позици€ спавна
                humansPrefabs[humansIndex].transform.rotation);//поворот префаба
        }
        
    }

    void IncreaseSpawnRate()
    {
        if (currentSpawnInterval > minSpawnInterval)
        {
            currentSpawnInterval -= spawnIntervalDecrease;
            CancelInvoke("SpawnRandoInterval");
            InvokeRepeating("SpawnRandoInterval", 0, currentSpawnInterval);
        }
    }

    void IncreaseSpawnCount()
    {
        if (currentSpawnCount < maxSpawnInterval)
        {
            currentSpawnCount++;
        }
    }
}
