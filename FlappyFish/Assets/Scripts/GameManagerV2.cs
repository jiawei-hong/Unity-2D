using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{
    public FishV2 fish;
    public Move[] moves;

    bool isGameOver;

    void Start()
    {
        fish.onCollided = OnFishCollided;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isGameOver)
            {
                if (fish.body.velocity.y <= 0)
                {
                    fish.body.velocity = new Vector2(0, fish.speed);
                }
            }
            else
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnFishCollided(Collider2D collision)
    {
        isGameOver = true;
        Destroy(fish.body);
        Destroy(fish);

        foreach (var m in moves)            
        {
            Destroy(m);
        }
    }
}
