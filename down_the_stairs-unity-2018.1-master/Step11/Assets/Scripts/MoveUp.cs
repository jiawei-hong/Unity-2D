using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 0.1f;

    public float maxPosition = 10f;

    public void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= maxPosition)
        {
            var position = transform.position;
            position.y = maxPosition;
            transform.position = position;

            Stop();
        }
    }

    public void Stop()
    {
        enabled = false;
    }
}
