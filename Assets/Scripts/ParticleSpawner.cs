using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject particleSystemPrefab1; // Assign the first particle system prefab in the inspector
    public GameObject particleSystemPrefab2; // Assign the second particle system prefab in the inspector

    public Vector3 spawnAreaMin; // Minimum position for random spawning
    public Vector3 spawnAreaMax; // Maximum position for random spawning

    public float spawnInterval = 2f; // Time interval between spawns

  

    public void SpawnParticleSystems()
    {
        
        // Generate random positions within the specified spawn area
        Vector3 randomPosition1 = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        Vector3 randomPosition2 = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Instantiate the particle systems at the random positions
        Instantiate(particleSystemPrefab1, randomPosition1, Quaternion.identity);
        Instantiate(particleSystemPrefab2, randomPosition2, Quaternion.identity);

       
    }
    public void CallSpawnParticleSystems()
    {
        spawnAreaMin += transform.position;
        spawnAreaMax += transform.position;
        SpawnParticleSystems();
        InvokeRepeating("SpawnParticleSystems", spawnInterval,1f);
    }
}
