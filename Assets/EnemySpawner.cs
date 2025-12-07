// 12/6/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Settings")]
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public int numberOfEnemies = 5; // Number of enemies to spawn
    public GridGenerator gridGenerator; // Reference to the GridGenerator script

    void Start()
    {
        // Find the GridGenerator component in the scene
        gridGenerator = FindObjectOfType<GridGenerator>();

        if (gridGenerator != null)
        {
            SpawnEnemies();
        }
        else
        {
            Debug.LogError("GridGenerator not found in the scene!");
        }
    }

    void SpawnEnemies()
    {
        List<GameObject> lavaTiles = new List<GameObject>();

        foreach (var tile in gridGenerator.grid)
        {
            if (tile.GetComponent<Renderer>().material.name.Contains("Lava"))
            {
                lavaTiles.Add(tile);
            }
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Select a random position on the grid
            int randomRow = Random.Range(0, lavaTiles.Count);
            GameObject tile = lavaTiles[randomRow];

            if (tile != null)
            {
                Vector3 spawnPosition = tile.transform.position + new Vector3(0, -0.1f, 0); // Adjust Y position to place enemy above the tile
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}