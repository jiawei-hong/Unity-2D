using UnityEngine;
using System;

public class FishV2 : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public float rotationScale;
    public Move[] moves;
    public Action<Collider2D> onCollided;
    
    void Update()
    {
        transform.localRotation = 
            Quaternion.Euler(0, 0, body.velocity.y * rotationScale);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        onCollided(collision);
    }
}
