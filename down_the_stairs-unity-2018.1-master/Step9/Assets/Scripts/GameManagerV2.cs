using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{
    public Transform obstacle;
    public float scrollSpeed = 0.3f;
    public float maxPosition = 10f;

    private PlayerV5 _player;
    private bool _isGameOver;


    private void Awake()
    {
        _player = FindObjectOfType<PlayerV5>();
        _player.onGameOver += _OnGameOver;
    }

    private void Update()
    {
        if (_isGameOver &&
            (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!_isGameOver && obstacle.position.y < maxPosition)
        {
            obstacle.Translate(0, scrollSpeed * Time.deltaTime, 0);

            if (obstacle.position.y >= maxPosition)
            {
                var position = obstacle.position;
                position.y = maxPosition;
                obstacle.position = position;
            }
        }
    }

    private void _OnGameOver()
    {
        _isGameOver = true;
        _player.Stop();

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            enemy.Stop();
        }
    }
}
