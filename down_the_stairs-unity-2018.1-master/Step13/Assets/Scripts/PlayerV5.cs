using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerV5 : MonoBehaviour
{
    public float force = 50f;
    public float speedLimit = 3f;
    public Action onGameOver;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private Rigidbody2D _body;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _renderer.flipX = false;
            _animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _renderer.flipX = true;
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_body.velocity.x < speedLimit)
            {
                _body.AddForce(new Vector2(force, 0));
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_body.velocity.x > -speedLimit)
            {
                _body.AddForce(new Vector2(-force, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead")
        {
            _animator.SetBool("Dead", true);
            onGameOver();
        }
        else if (collision.tag == "FinishLine")
        {
            _animator.SetBool("Finished", true);
            onGameOver();
        }
    }

    public void Stop()
    {
        _body.velocity = Vector2.zero;
        _body.simulated = false;
        enabled = false;
    }
}
