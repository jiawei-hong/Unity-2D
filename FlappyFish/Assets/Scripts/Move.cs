using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }
}
