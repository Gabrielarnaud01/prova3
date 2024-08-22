using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas
using UnityEngine.UI; // Para usar o componente Image

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    public float playerSpeed;
    public float playerInicialSpeed;
    public float playerRunSpeed;
    public Animator animator;

    // Adicionando variáveis para o sistema de vida
    public int maxHealth = 3; // Número total de corações
    private int currentHealth;

    // Variável para o dano de teste
    public float testDamageAmount = 1; // Dano aplicado ao pressionar a tecla Espaço

    // Referências às imagens dos corações
    public Image heart0;
    public Image heart1;
    public Image heart2;

    public float attackRange = 2.0f;
    public Transform attackPoint;
    private Vector2 lastMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerInicialSpeed = playerSpeed;
        animator = gameObject.GetComponent<Animator>();

        // Inicializa a vida atual com a vida máxima
        currentHealth = maxHealth;

        // Inicializa os corações
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        AnimateMovent(direction);

        transform.position += direction * playerSpeed * Time.deltaTime;

        Flip(direction);
        PlayerRun();

        // Atualiza a direção do movimento com base na entrada do jogador
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isAttacking");

            // Raycast na direção em que o jogador atacou pela última vez
            RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, lastMoveDirection, attackRange);

            // Verifica se o Raycast colidiu com algo que tenha a tag "Enemy"
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(1);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(attackPoint.position, attackPoint.position + transform.right * attackRange);
    }

    void AnimateMovent(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    void Flip(Vector3 direction)
    {
        // Ajusta a escala do transform para espelhar a animação
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Direita
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Esquerda
        }
    }

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = playerRunSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = playerInicialSpeed;
        }
    }

    // Método para aplicar dano ao jogador
    public void TakeDamage(float damageAmount)
    {
        // Reduz a vida do jogador
        currentHealth -= Mathf.RoundToInt(damageAmount);
        Debug.Log("Current Health: " + currentHealth);

        // Atualiza a exibição dos corações
        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para atualizar a exibição dos corações
    void UpdateHearts()
    {
        // Define a visibilidade dos corações com base na saúde atual
        heart0.enabled = currentHealth > 2;
        heart1.enabled = currentHealth > 1;
        heart2.enabled = currentHealth > 0;
    }

    // Método chamado quando a vida chega a zero
    void Die()
    {
        Debug.Log("Player has died");
        SceneManager.LoadScene("TryAgain");
    }


}
