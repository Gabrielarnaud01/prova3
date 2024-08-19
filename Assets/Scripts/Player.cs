using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour

{

    private Rigidbody2D _playerRigidbody2D;
    public float playerSpeed;
    public float playerInicialSpeed;
    public float playerRunSpeed;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerInicialSpeed = playerSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
 
        Vector3 direction = new Vector3(horizontal,vertical);

        AnimateMovent(direction);

        transform.position += direction * playerSpeed * Time.deltaTime;

        Flip(direction);
        PlayerRun();
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
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
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
}
