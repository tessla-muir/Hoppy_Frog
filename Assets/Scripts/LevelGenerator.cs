using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject highPlatformPrefab;
    public Transform player;


    private int platformCount = 2;
    public int maxPlatforms = 18;
    private float maxHeight = 0;
    private float lastPlatformHeight = 0;
    private string lastPlatformType = "normal";

    public float levelWidth = 5f;
    private float minY = .2f;
    private float maxY = 1.2f;

    private GameObject[] platforms;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = platformCount; i < maxPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platformCount++;

            if (spawnPosition.y > lastPlatformHeight) {
                lastPlatformHeight = spawnPosition.y;
            }
        }
    }

    void Update() 
    {
        // Updates maxHeight player has reached
        if (player.position.y > maxHeight) 
        {
            maxHeight = player.position.y;
        }

        platforms = GameObject.FindGameObjectsWithTag("platform");

        // Deletes old platforms
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].transform.position.y + 5f < player.position.y)
            {
                Destroy(platforms[i]);
                platformCount--;
            }
        }
    }

    void LateUpdate() 
    {
        Vector3 spawnPosition = new Vector3();

        // Adds new platform
        if (platformCount < maxPlatforms)
        {
            // Look at last platform type
            if (lastPlatformType == "normal") {
                spawnPosition.y += Random.Range(lastPlatformHeight + .8f, lastPlatformHeight + 1.4f);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            } else {
                spawnPosition.y += Random.Range(lastPlatformHeight + 1.4f, lastPlatformHeight + 2.2f);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            }

            lastPlatformHeight = spawnPosition.y;

            // Math to determine new platform
            float determiner = Random.Range(1, 100);

            if (determiner < 8) {
                Instantiate(highPlatformPrefab, spawnPosition, Quaternion.identity);
                lastPlatformType = "high";
            } else {
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                lastPlatformType = "normal";
            }

            platformCount++;
        }
    }
}
