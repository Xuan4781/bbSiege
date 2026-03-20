using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float survivalTime = 0f;
    public TMP_Text timerText;

    public bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            survivalTime += Time.deltaTime;

            if (timerText != null)
                timerText.text = "Time: " + Mathf.FloorToInt(survivalTime);
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        PlayerPrefs.SetFloat("HighScore",
            Mathf.Max(PlayerPrefs.GetFloat("HighScore", 0), survivalTime));
    }
}
