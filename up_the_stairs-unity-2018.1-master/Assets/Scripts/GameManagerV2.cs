using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public float middleRange = 50f;

    private PlayerBase _player;
    private bool _isGameOver;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerBase>();
        _player.onGameOver += _OnGameOver;
    }

    private void Update()
    {
        if (_isGameOver)
        {
            if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
         {
            var c = Camera.main;
            var p = c.WorldToScreenPoint(_player.transform.position);
            
            if (p.y - Screen.height / 2 > middleRange)
            {
                c.transform.position +=
                    new Vector3(0, scrollSpeed, 0);
            }
            else if (p.y - Screen.height / 2 < -middleRange)
            {
                c.transform.position +=
                    new Vector3(0, -scrollSpeed, 0);
            }

            if (c.transform.position.y < 0)
            {
                c.transform.position = 
                    new Vector3(
                        c.transform.position.x, 
                        0, 
                        c.transform.position.z);
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
