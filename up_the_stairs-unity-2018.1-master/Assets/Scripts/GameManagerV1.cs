using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV1 : MonoBehaviour
{
    private PlayerBase _player;
    private bool _isGameOver;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerBase>();
        _player.onGameOver += _OnGameOver;
    }

    private void Update()
    {
        if (_isGameOver &&
            (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
