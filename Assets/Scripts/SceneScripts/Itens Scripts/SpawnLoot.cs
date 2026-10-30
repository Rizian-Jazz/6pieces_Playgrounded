using UnityEngine;
using System.Collections;
public class SpawnLoot : MonoBehaviour
{
    PlayerLevel playerLevel;
    public GameObject player, LootPrefab;
    public float spawnCooldown = 30f, spawnRadius = 5f, spawnTime = 10f;
    private bool isSpawning = false;
    public bool Spawned = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = FindFirstObjectByType<PlayerLevel>();
    }
    void Update()
    {
        if (playerLevel != null && playerLevel.currentLevel >= 10 && !isSpawning)
        {
            StartCoroutine(SpawningLoot());
        }
    }
    public IEnumerator SpawningLoot()
    {
        isSpawning = true;  

        Spawned = true;
        while(isSpawning)
        {
            yield return new WaitForSeconds(spawnTime);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = (Vector2)player.transform.position + randomPosition;
            Instantiate(LootPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Loot spawned!!");
            yield return new WaitForSeconds(spawnCooldown);
        }
        isSpawning = false;
    }

    
    
}
