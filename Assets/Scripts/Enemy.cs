using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float detectionRadius;
    public int maxHealth = 3;
    private int currentHealth;

    private Transform player;
    private Rigidbody2D _enemyRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyRigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Persegue o jogador se estiver dentro do raio de detecção
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            _enemyRigidbody2D.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
    }

    // Método para aplicar dano ao inimigo
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método chamado quando a vida do inimigo chega a zero
    void Die()
    {
        Debug.Log("Enemy has died");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }
}
