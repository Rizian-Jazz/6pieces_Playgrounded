using UnityEngine;
using System.Collections;
public class SpawnLoot : MonoBehaviour
{
    PlayerLevel playerLevel;
    Timer timer;
    public GameObject player, LootPrefab;
    public float spawnCooldown = 30f, spawnRadius = 5f;
    private bool isSpawning = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = FindFirstObjectByType<PlayerLevel>();
        timer = FindFirstObjectByType<Timer>();
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
        timer.isRunning = true;
        while(timer.time <= 0f)
        {
            timer.isRunning = false;
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = (Vector2)player.transform.position + randomPosition;
            Instantiate(LootPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Loot spawned!!");
            yield return new WaitForSeconds(spawnCooldown);
        }
        isSpawning = false;
    }

    
    
}
