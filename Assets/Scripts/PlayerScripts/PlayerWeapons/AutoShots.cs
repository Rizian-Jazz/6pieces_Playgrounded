using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

public class AutoShots : MonoBehaviour
{   
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f, bulletInterval = 0.4f;
    public Transform firePoint; 
    public static bool canThrow = true;
    private Coroutine fireCoroutine;

    public void FixedUpdate()
    {
        if (canThrow == true && fireCoroutine == null) 
        {  
            fireCoroutine = StartCoroutine(FireLoop());
        }
        else if (canThrow == false && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    
    IEnumerator FireLoop()
    {
        
        while (canThrow == true)
        {
            yield return new WaitForSeconds(bulletInterval);
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = firePoint.up * bulletSpeed;
            }

        }            
    }
    
}
