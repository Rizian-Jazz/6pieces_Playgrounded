using UnityEngine;

public class EnemieManager : BaseCharacterController
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 5f;
    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);   
        //achei melhor colocar o movimento no manager já que todos os inimigos (com exeção de bosses talvez) seguem o player    
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {}
    public override void OnTriggerEnter2D(Collider2D collision)
    {}
}
