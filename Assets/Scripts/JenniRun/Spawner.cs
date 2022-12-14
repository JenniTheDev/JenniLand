using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private int obstaclePoolSize = 20;
    [SerializeField] private int bufferSize = 2;
    [SerializeField] private List<GameObject> obstaclesToSpawn;
    [SerializeField] private Stack<GameObject> obstaclePool = new();
    [SerializeField] private Transform obstacleContainer;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private JenniRunEventManager gameEventManager;

    private int obstacleNumber;

    private bool isSpawning;

    private float spawnDelayTimer;

    private void Start()
    {
        spawnDelayTimer = spawnRate;
        StartCoroutine(IncreasePool(obstaclePoolSize));
    }

    private void Update()
    {
        if (isSpawning)
        {
            CheckAndSpawnBalls();
        }
    }

    private void OnEnable()
    {
        gameEventManager.OnJenniRunGameStart += StartSpawning;
        gameEventManager.OnJenniRunGameStop += StopSpawning;
    }

    private void OnDisable()
    {
        gameEventManager.OnJenniRunGameStart -= StartSpawning;
        gameEventManager.OnJenniRunGameStop -= StopSpawning;
    }

    private void StartSpawning()
    {
        isSpawning = true;
    }

    private void CheckAndSpawnBalls()
    {
        spawnDelayTimer -= Time.deltaTime;
        if (spawnDelayTimer <= 0f)
        {
            var goToSpawn = Get();
            goToSpawn.transform.position = spawnLocation.position;

            spawnDelayTimer = spawnRate;
        }
    }

    private IEnumerator IncreasePool(int incBy)
    {
        GameObject prefab, goToAdd;

        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacleNumber = Random.Range(0, obstaclesToSpawn.Count);
            prefab = obstaclesToSpawn[obstacleNumber];
            goToAdd = Instantiate(prefab, spawnLocation.position, prefab.transform.rotation, obstacleContainer);
            goToAdd.SetActive(false);
            obstaclePool.Push(goToAdd);
            yield return null;
        }
    }

    private GameObject Get(bool activateOnGet = true)
    {
        GameObject result = null;
        if (obstaclePool.Count > bufferSize)
        {
            result = obstaclePool.Pop();
        }
        else if (obstaclePool.Count > 0)
        {
            result = obstaclePool.Pop();
            StartCoroutine(IncreasePool(bufferSize));
        }
        else
        {
            obstacleNumber = Random.Range(0, obstaclesToSpawn.Count);
            var prefab = obstaclesToSpawn[obstacleNumber];
            result = Instantiate(prefab, spawnLocation.position, prefab.transform.rotation, obstacleContainer);
            StartCoroutine(IncreasePool(bufferSize));
        }
        if (activateOnGet) { result.SetActive(true); }
        // Debug.Log($"Get remaining: {obstaclePool.Count} ");
        return result;
    }

    public void Return(GameObject toReturn)
    {
        toReturn.SetActive(false);
        obstaclePool.Push(toReturn);
        // Debug.Log($"Return remaining: {obstaclePool.Count} ");
    }

    private void StopSpawning()
    {
        isSpawning = false;
        ResetSpawner();
    }

    private void ResetSpawner()
    {
        foreach (Transform child in obstacleContainer)
        {
            Return(child.gameObject);
        }
    }
}