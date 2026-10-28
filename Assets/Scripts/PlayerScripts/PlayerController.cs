using System.Collections;
using UnityEngine;

public class PlayerController : BaseCharacterController
{
    public Rigidbody2D rb;
    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void FixedUpdate()
    {}
    public override void OnCollisionEnter2D(Collision2D collision)
    {}
    public override void OnTriggerEnter2D(Collider2D collision)
    {}
        

}

