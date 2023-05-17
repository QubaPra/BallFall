using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] cloudPrefabs; // Array of cloud prefabs
    public CurrentLevel currentLevelScript;
    public float minX = -11.5f; // Minimum x coordinate
    public float maxX = 11.5f; // Maximum x coordinate

    public void SpawnCloud()
    {
            float levelY = currentLevelScript.levelY;

            // Generate a random x coordinate
            float randomX = Random.Range(minX, maxX);

            // Select a random cloud prefab
            int prefabIndex = Random.Range(0, cloudPrefabs.Length);

            GameObject firstSelectedPrefab = cloudPrefabs[prefabIndex];

            // Spawn the cloud at the random x coordinate
            Instantiate(firstSelectedPrefab, new Vector3(randomX, levelY, 2.9f), Quaternion.identity);
    }
}