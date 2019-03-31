using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerV4 : MonoBehaviour
{
    public FishV2 fish;
    public Move[] moves;
    public Collider2D finishLine;
    public AudioSource jumpAudio;
    public AudioSource deadAudio;
    public AudioSource finishAudio;
    public AudioSource startAudio;
    public Canvas canvas;
    public Button button;
    public Image cover;
    public Color deadColor;
    public Color finishColor;

    bool isGameOver;
    bool isStarted;

    void Start()
    {
        fish.onCollided = OnFishCollided;
        button.onClick.AddListener(OnStartbuttonClicked);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isStarted)
            {
                if (!isGameOver)
                {
                    if (fish.body.velocity.y <= 0)
                    {
                        fish.body.velocity = new Vector2(0, fish.speed);
                        jumpAudio.Play();
                    }
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    void OnFishCollided(Collider2D collision)
    {
        isGameOver = true;
        Destroy(fish.body);
        Destroy(fish);

        foreach (var m in moves)
            Destroy(m);

        ShowGameOver(
            finishLine != null &&
                 collision.transform == finishLine.transform);
    }

    void ShowGameOver(bool isFinished)
    { 
        canvas.enabled = true;
        button.gameObject.SetActive(false);

        if (isFinished)
        {
            finishAudio.Play();
            cover.color = finishColor;
        }
        else
        {   
            deadAudio.Play();
            cover.color = deadColor;       
        }
    }

    void OnStartbuttonClicked()
    {
        isStarted = true;
        startAudio.Play();
        fish.body.simulated = true;     
        fish.enabled = true;
        foreach (var m in moves)
        {
            m.enabled = true;
        }
        canvas.enabled = false;
    }
}
