using UnityEngine;
using System;

public class FishV1 : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public float rotationScale;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (body.velocity.y <= 0)
            {
                body.velocity = new Vector2(0, speed);
            }
        }

        transform.localRotation = 
            Quaternion.Euler(0, 0, body.velocity.y * rotationScale);
    }
}
