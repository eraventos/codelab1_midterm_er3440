using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCollector : MonoBehaviour
{
    //declaring variables
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text timerText;
    public int targetScore = 10;
    public int highScore;
    public float timer = 0;
    public float timerDuration;
    public bool runTimer = false;
    public bool isStartLevel;

    // Singleton instance
    public static PlayerCollector instance;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object across scenes
        }
        else
        {
            instance.transform.position = transform.position;
            instance.transform.rotation = transform.rotation;
            instance.scoreText = scoreText; // telling the player to pass on score reference and current score
            instance.highScoreText = highScoreText; // telling it to pass on high score info
            instance.timerText = timerText; // show timer
            instance.runTimer = runTimer; // setting the singleton runtime value to be our time value. 
            instance.timer = timerDuration; // singleton set your timer value to our timer duration value TimerDiration how long we want it to last
            if (isStartLevel)
            {
                instance.score = 0;
            }

            Destroy(gameObject);  // Destroy the duplicate if another instance exists
        }
    }

    private void Start()
    {
        //name it more general 
        UpdateUI();
    }
    
    void Update()
    {
        Debug.Log(score);

        if (targetScore == score)
        {
            targetScore *= 10;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (runTimer)
        {
            timer -= Time.deltaTime; //-= shorthand whatever my current value is make it - whatever value I put at the end timer = timer - Time.deltatime
            if (timer <= 0)
            {
                SceneManager.LoadScene(0);
            }

        }
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            score++;
            AudioManager.PlayTwinkle();
            if (score > highScore)
            {
                highScore = score;
            }
            
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Lilies: " + score;
        highScoreText.text = "High Score: " + highScore;
        timerText.text = "Time Left: " + timer;
        timerText.gameObject.SetActive(runTimer);
        
    }
}


