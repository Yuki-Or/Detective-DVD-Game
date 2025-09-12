using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSpawner : MonoBehaviour
{
    public GameObject facePrefab;
    public Transform spawnParent;
    private Vector2 spawnPosition;
    private float spawnDelay = 5f;
    private float secondSpawnDelay = 8f;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        minX = 190;
        maxX = 200;
        minY = 90;
        maxY = 100;
        StartCoroutine(SpawnAfterDelay(spawnDelay));
        StartCoroutine(SpawnAfterDelay(secondSpawnDelay));
    }

    private IEnumerator SpawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 spawnPosition = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );

        GameObject newFace = Instantiate(facePrefab, spawnPosition, Quaternion.identity, spawnParent);
    }
}
