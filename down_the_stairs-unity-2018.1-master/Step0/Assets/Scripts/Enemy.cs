using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public Waypoint next;

    private SpriteRenderer _renderer;
    private Rigidbody2D _body;
    private Animator _animator;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var direction =
            (next.transform.position - transform.position).normalized;

        _renderer.flipX = direction.x >= 0;

        _body.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var waypoint = collision.GetComponent<Waypoint>();

        if (waypoint != null && waypoint == next)
        {
            next = waypoint.next;
        }
    }

    public void Stop()
    {
        _body.simulated = false;
        _animator.enabled = false;
        enabled = false;
    }
}
