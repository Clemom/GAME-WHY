using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public Transform spawnPoint;
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 5f;
    public float minY = -1f;
    public float maxY = 2f;

    void Start()
    {
        StartCoroutine(SpawnCollectibles());
    }

    IEnumerator SpawnCollectibles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

            Vector3 spawnPosition = spawnPoint.position + new Vector3(0, Random.Range(minY, maxY), 0);
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
