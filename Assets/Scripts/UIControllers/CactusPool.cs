using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusPool : MonoBehaviour
{
    [SerializeField]
    public int cactusPoolSize = 7;

    [SerializeField]
    public float spawnRate;
    [SerializeField]
    public float cactusMin = -2.7f;
    [SerializeField]
    public float cactusMax = -1.8f;
    [SerializeField]
    public float minTime;
    [SerializeField]
    public float maxTime;
    [SerializeField]
    private float spawnXPosition = 11f;

    [SerializeField]
    private Vector2 objectPoolPosition = new Vector2(4.5f, -1.8f);

    private GameObject[] cactuses;
    public ScriptableCactus scriptableCactus;
    private float timeSinceLastSpawn;

    private int currentCactus = 0;

    private void Start()
    {
        GeneratePool();
    }
    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (ScoreManager.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = Random.Range(cactusMin, cactusMax);
            cactuses[currentCactus].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentCactus++;

            if (currentCactus >= cactusPoolSize)
            {
                currentCactus = 0;
            }
        }
    }
    private void GeneratePool()
    {
        cactuses = new GameObject[cactusPoolSize];

        StartCoroutine(PoolQueue());
    }
    IEnumerator PoolQueue()
    {
        for (int i = 0; i < cactusPoolSize; i++)
        {
            cactuses[i] = GameObject.Instantiate(scriptableCactus.cactusPrefab, objectPoolPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate = Random.Range(minTime, maxTime));
        }
    }
}
