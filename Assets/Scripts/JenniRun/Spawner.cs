using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private int obstaclePoolSize = 20;
    [SerializeField] private List<GameObject> obstaclesToSpawn;
    [SerializeField] private List<GameObject> obstaclePool;
    [SerializeField] private Transform obstacleContainer;
    [SerializeField] private Collider spawnArea;

    private int obstacleNumber;

    private float spawnDelayTimer;

    private void Awake()
    {
        spawnDelayTimer = spawnRate;
        CreateObstaclePool();
    }

    private void Update()
    {
        CheckAndSpawnBalls();
    }

    private Vector2 GetSpawnLocation()
    {
        Vector2 spawn = spawnArea.bounds.center;
        spawn.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

        return spawn;
    }

    private void CheckAndSpawnBalls()
    {
        spawnDelayTimer -= Time.deltaTime;
        if (spawnDelayTimer <= 0f)
        {
            obstacleNumber = Random.Range(0, obstaclePool.Count);
            obstaclePool[obstacleNumber].transform.position = GetSpawnLocation();
            obstaclePool[obstacleNumber].SetActive(true);

            spawnDelayTimer = spawnRate;
        }
    }

    private void CreateObstaclePool()
    {
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacleNumber = Random.Range(0, obstaclesToSpawn.Count);
            var obstacle = obstaclesToSpawn[obstacleNumber]; // here 
            obstaclePool.Add(obstacle);
            Instantiate(obstacle, GetSpawnLocation(), Quaternion.identity, obstacleContainer);
            obstacle.SetActive(false);
        }
    }
}