using UnityEngine;

public class Neddle : MonoBehaviour {
    public float Speed = 0.1f;
    public bool isFired = false;
    public GameObject Rectangle = null;

	void Update () {    
        if (isFired)
        {
            transform.Translate(new Vector3(0, Speed, 0));
            Rectangle.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isFired = false;
        transform.SetParent(collision.transform);
    }
}
