using UnityEngine;
using System.Collections;

public class EnemieHealth : EnemieManager
{
    public int EnemyHealth = 100, enemyCurrentHealth, EnemyDamage = 5;
    public float damageCooldown = 0.1f;
    
    public override void Start()
    {
        base.Start();
        enemyCurrentHealth = EnemyHealth;
    }
    
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(EnemyDamage);
                Debug.Log("Enemy collided with player! Player takes " + EnemyDamage + " damage.");
            }
        }
        if (collision.gameObject.CompareTag("Enemie"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
    public void TakeDamage(int amount)
    {
        StartCoroutine(Damage(amount));
    }

    IEnumerator Damage(int amount)
    {
        enemyCurrentHealth -= amount;
        if (enemyCurrentHealth <= 0)
        {
            Debug.Log("Enemy morreu");
            Destroy(gameObject);
            EnemieSpawn enemieSpawn = FindFirstObjectByType<EnemieSpawn>();
            if (enemieSpawn != null)
            {
                enemieSpawn.currentEnemies--;
            }
        }
        yield return new WaitForSeconds(damageCooldown);
    }
}
