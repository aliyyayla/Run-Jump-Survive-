using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab; // The object to spawn
        [Range(0f, 1f)]
        public float spawnChance; // Chance for this object to spawn
    }

    public SpawnableObject[] objects; // Array of objects to spawn
    public float spawnInterval = 2f; // Time interval between spawns
    public Transform spawnPoint; // Where the objects will spawn

    private void Start()
    {
        // Start the spawning loop
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomValue = Random.value; // Random value between 0 and 1
            foreach (var obj in objects)
            {
                if (randomValue <= obj.spawnChance)
                {
                    Debug.Log($"Spawning: {obj.prefab.name}"); // Add this line
                    Instantiate(obj.prefab, spawnPoint.position, Quaternion.identity);
                    break; // Stop after spawning one object
                }
            }
        }
    }

}
