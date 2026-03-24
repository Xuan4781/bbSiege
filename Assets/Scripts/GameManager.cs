using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float survivalTime = 0f;
    public TMP_Text timerText;

    public GameObject startPanel;
    bool gameStarted = false;

    public EnemySpawner spawner;
    public GameObject gameOverPanel;
    public TMP_Text finalTimeText;
    public TMP_Text highScoreText;

    public bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted || isGameOver) return;
        
        survivalTime += Time.deltaTime;

        if (timerText != null){
            timerText.text = "Time: " + Mathf.FloorToInt(survivalTime);
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1f;
        spawner.BeginSpawning();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        float highScore = PlayerPrefs.GetFloat("HighScore", 0);

        if (survivalTime > highScore)
        {
            highScore = survivalTime;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        // show the ui
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (finalTimeText != null)
            finalTimeText.text = "Time: " + Mathf.FloorToInt(survivalTime);

        if (highScoreText != null)
            highScoreText.text = "High Score: " + Mathf.FloorToInt(highScore);

        
    }


     public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
