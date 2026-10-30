using UnityEngine;
using System.Collections;
public class Loot : MonoBehaviour
{
    SpawnLoot spawnLoot;
    public bool isLootCollected = false;

    void Start()
    {
        spawnLoot = FindFirstObjectByType<SpawnLoot>();
    }

    void Update()
    {
        if (spawnLoot.Spawned)
        {
            StartCoroutine(DestroyLoot());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLootCollected = true;
            Destroy(gameObject);
        }
    }
    public IEnumerator DestroyLoot()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    //1- verificar se o player colidiu com o bau 
    //2- se sim, Verificar vida do player, se for menor que 25, dar item de cura
    //3- se for maior que 25, verificar nivel do player
    //4- mudar a chance de obter qualidades de itens diferentes dependendo do nivel do player (sla. 10- 100% comum, 21-40 é 50% raro, 41- 66 é 25% pog, 67-100 é 10% mega poggers) algo assim tlgd (nao terminei o fluxograma)
    //5- dar item pro player e destruir o bau
    //6- criar um inventario pro player pra poder enfiar esses itens (coisa pra dps.. *emoji averiguando a resenha*)
}
