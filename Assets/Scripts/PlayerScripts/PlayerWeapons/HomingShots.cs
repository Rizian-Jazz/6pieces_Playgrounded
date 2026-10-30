using UnityEngine;

public class HomingShots : MonoBehaviour
{
    public float bulletSpeed = 3f;
    public float rotationSpeed = 100f;
    public int bulletDamage = 50; 

    public Rigidbody2D rb;
    public Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindTarget();
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            rb.angularVelocity = 0f;
            rb.linearVelocity = transform.up * bulletSpeed;
            return;
        }

        Vector2 direction = ((Vector2)target.position - rb.position).normalized;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotationSpeed * 10f;

        rb.linearVelocity = transform.up * bulletSpeed;
    }

    public void FindTarget()
    {
        GameObject enemyObj = GameObject.FindWithTag("Enemie");
        if (enemyObj != null)
        {
            target = enemyObj.transform;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemie"))
        {
            EnemieHealth enemyHealth = collision.GetComponent<EnemieHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
                Debug.Log("Bullet collided with enemy! Enemy takes " + bulletDamage + " damage.");
            }
            Destroy(gameObject);
        }
    }
}
