using UnityEngine;

public class XPOrb : MonoBehaviour
{
    PlayerLevel playerLevel;
    public int XPValue = 10;

    void Start()
    {
        playerLevel = FindFirstObjectByType<PlayerLevel>();
        playerLevel.XPValue = XPValue;
    }
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerLevel != null)
            {
                playerLevel.LevelUp(playerLevel.XPValue);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Enemie"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
