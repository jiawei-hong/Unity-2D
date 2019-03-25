using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {
    public float Speed = 0.1f;
    public bool IsFired;
    public GameObject rectangle = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsFired)
        {            
            transform.Translate(new Vector3(0, Speed, 0));
            rectangle.SetActive(true);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        IsFired = false;
        transform.SetParent(collision.transform);
    }
}
