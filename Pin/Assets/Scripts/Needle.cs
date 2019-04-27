using System;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public float speed = 0.1f;

    public bool isFired;

    public GameObject rectangleGameObject;

    public Rigidbody2D body;

    public Action<Needle, Collider2D> OnCollided;

    

    void Update()
    {      
        if (isFired)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime * 60, 0));
            rectangleGameObject.SetActive(true);
            body.simulated = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollided(this, collision);
    }
}
