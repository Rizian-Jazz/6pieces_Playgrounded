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
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerLevel != null)
            {
                playerLevel.LevelUp(playerLevel.XPValue);
                Debug.Log("Player collected XP orb!");
                Destroy(gameObject);
            }
        }
        if(collision.CompareTag("Enemie"))
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}
