using UnityEngine;
using System.Collections;
public class EnemieSpawn : MonoBehaviour
{
    public GameObject enemiePrefab;
    public Transform spawnPoint;
    public float spawnCooldown = 2f;
    public int maxEnemies = 100, distanceToSpawn = 10;
    public int currentEnemies = 0;
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform; 
        StartCoroutine(SpawnEnemie(spawnCooldown));
    }
    
    public IEnumerator SpawnEnemie(float spawnCooldown)
    {
        while (currentEnemies < maxEnemies)
        {
            yield return new WaitForSeconds(spawnCooldown);
            float randomX = Random.Range(-10f, 10f);
            float randomY = Random.Range(-10f, 10f);
            Vector2 spawnPosition = new Vector2(randomX, randomY).normalized * distanceToSpawn; 

            if(spawnPosition == Vector2.zero)
            {
                spawnPosition = new Vector2(1f, 0f) * distanceToSpawn; 
            }

            Vector2 NewspawnPosition = new Vector2(spawnPoint.position.x, spawnPoint.position.y) + spawnPosition;

            Instantiate(enemiePrefab, NewspawnPosition, Quaternion.identity);
            currentEnemies++;
        }
    }
}
