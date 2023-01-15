using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D rb2d;
    Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }
    void Update()
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal")*speed * Time.deltaTime), charPos.y);
        transform.position = charPos;
        if(Input.GetAxis("Horizontal")==0f)
        {
            _animator.SetFloat("speed", 0);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }

        
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z-1f); 
    }
}
