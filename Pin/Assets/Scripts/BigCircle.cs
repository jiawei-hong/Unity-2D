using UnityEngine;

public class BigCircle : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * 60));
    }
}