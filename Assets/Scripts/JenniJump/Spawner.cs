using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclesToSpawn;
    [SerializeField] private Transform obstacleContainer;
    private int obstacleNumber;
    private int numberToSpawn = 1;
    private int maxSpawnLimit = 20;
    private float spawnRate = 1.5f;
    private float spawnDelayTimer;
    //private Vector2 center;

    [SerializeField] private Collider spawnArea;

    private void Start()
    {
        // center = new Vector2(0, 1);
        spawnDelayTimer = spawnRate;
    }

    private void Update()
    {
        CheckAndSpawnBalls();
    }

    private Vector3 GetSpawnLocation()
    {
        Vector2 spawn = spawnArea.bounds.center;
        spawn.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

        return spawn;
    }

    private void CheckAndSpawnBalls()
    {
        if (obstacleContainer.childCount < maxSpawnLimit)
        {
            spawnDelayTimer -= Time.deltaTime;
            if (spawnDelayTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    obstacleNumber = Random.Range(0, obstaclesToSpawn.Count);
                    Instantiate(obstaclesToSpawn[obstacleNumber], GetSpawnLocation(), Quaternion.identity, obstacleContainer);
                }
                spawnDelayTimer = spawnRate;
            }
        }
    }
}