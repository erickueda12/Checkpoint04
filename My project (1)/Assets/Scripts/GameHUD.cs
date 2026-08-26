using TMPro;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [Header("HUD")]
    public GameObject hudPanel;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timerText;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    public TMP_Text resultText;
    public TMP_Text finalScoreText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        gameManager.OnScoreChanged += UpdateScore;
        gameManager.OnLivesChanged += UpdateLives;
        gameManager.OnTimeChanged += UpdateTimer;
        gameManager.OnGameEnded += ShowGameOver;

        UpdateScore(gameManager.score);
        UpdateLives(gameManager.lives);
        UpdateTimer(gameManager.currentTime);

        hudPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    private void UpdateScore(int value)
    {
        scoreText.text = "Score: " + value;
    }

    private void UpdateLives(int value)
    {
        livesText.text = "Lives: " + value;
    }

    private void UpdateTimer(float value)
    {
        timerText.text = "Time: " + Mathf.CeilToInt(value);
    }

    private void ShowGameOver(bool won)
    {
        hudPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if (won)
        {
            resultText.text = "VITÓRIA!";
        }
        else
        {
            resultText.text = "DERROTA!";
        }

        finalScoreText.text = "Score: " + gameManager.score;
    }

    public void RestartGame()
    {
        gameManager.RestartGame();
    }

    private void OnDestroy()
    {
        gameManager.OnScoreChanged -= UpdateScore;
        gameManager.OnLivesChanged -= UpdateLives;
        gameManager.OnTimeChanged -= UpdateTimer;
        gameManager.OnGameEnded -= ShowGameOver;
    }
}