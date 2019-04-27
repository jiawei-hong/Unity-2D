using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Needle needlePrefab;
    public BigCircle bigCircle;
    public AudioSource deadAudio;
    public AudioSource scoresAudio;
    public AudioSource backgroundAudio;
    public Text message;
    public Text scoresLabel;
    public int maxScores;
    public string nextSceneName;
    public string deadSceneName;
    public Text timerText;

    int scores;
    Needle currentNeedle;
    bool GameOver;
    bool isFinished;
    float timer = 0;

    void Start()
    {
        SpawnNeedle();
        backgroundAudio.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameOver && !isFinished)
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


        timer += Time.deltaTime;
        if (GameOver == false && isFinished == false)
        {
            timerText.text = "時間：" + ((int)timer).ToString() + "秒";
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
        GameOver = true;
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
        message.text = "恭 喜 過 關";
    }
}