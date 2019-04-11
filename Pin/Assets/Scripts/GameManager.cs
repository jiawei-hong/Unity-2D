using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Needle needlePrefab;
    public BigCircle bigCircle;
    public AudioSource deadAudio;
    public AudioSource scoresAudio;
    public Text message;
    public Text scoresLabel;
    public int maxScores;
    public string nextSceneName;
    public string deadSceneName;

    int scores;
    Needle currentNeedle;
    bool isGameOver;
    bool isFinished;

    void Start()
    {
        SpawnNeedle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isGameOver && !isFinished)
            {
                currentNeedle.isFired = true;
                SpawnNeedle();            
            }
            else if (isFinished) 
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                SceneManager.LoadScene(deadSceneName);
            }
        }
    }

    void SpawnNeedle()
    {
        currentNeedle = Instantiate(needlePrefab);
        currentNeedle.OnCollided = OnNeedleCollided;
        currentNeedle.gameObject.SetActive(true);
    }

    void OnNeedleCollided(Needle needle, Collider2D collision)
    {
        needle.isFired = false;
        needle.transform.SetParent(collision.transform);

        if (collision.transform == bigCircle.transform)
        {
            needle.transform.localPosition = Vector3.zero;
        }

        Destroy(needle.body);
        Destroy(needle);

        if (collision.transform != bigCircle.transform)
        {
            Die();
        }
        else
        {
            Scores();
        }
    }

    void Die()
    {
        isGameOver = true;
        Destroy(bigCircle);
        deadAudio.Play();
        message.gameObject.SetActive(true);
    }

    void Scores()
    {
        scoresAudio.Play();
        scores++;
        scoresLabel.text = scores.ToString();
        if (scores >= maxScores)
        {
            Finish();
        }
    }

    void Finish()
    {
        isFinished = true;
        Destroy(bigCircle);
        message.gameObject.SetActive(true);
        message.text = "Click to Continue";
    }
}