using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 150f;
    public float speed;
    private float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool isMoving;

    SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }

    }
    private void Update()
    {
        if (grounded == true && ((Input.GetKey(KeyCode.A)) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0f;
            anim.SetFloat("speed", 0f);
        }

        if (grounded && Input.GetKey(KeyCode.Space))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
    }
}
