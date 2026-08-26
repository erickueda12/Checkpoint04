using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Partida")]
    public int score;
    public int lives = 3;

    [Header("Tempo")]
    public float gameTime = 60f;
    public float currentTime;

    public GameStateMachine machine { get; private set; }

    public PlayingState playingState;
    public GameOverState gameOverState;

    public Action<int> OnScoreChanged;
    public Action<int> OnLivesChanged;
    public Action<float> OnTimeChanged;

    public Action<IGameState> OnStateChanged;
    public Action<bool> OnGameEnded;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        machine = new GameStateMachine();

        playingState = new PlayingState(this);
        gameOverState = new GameOverState(this);
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        machine.Tick();
    }

    public void ChangeState(IGameState newState)
    {
        machine.ChangeState(newState);

        OnStateChanged?.Invoke(newState);
    }

    public void StartGame()
    {
        score = 0;
        lives = 3;
        currentTime = gameTime;

        OnScoreChanged?.Invoke(score);
        OnLivesChanged?.Invoke(lives);
        OnTimeChanged?.Invoke(currentTime);

        ChangeState(playingState);
    }

    public void AddScore(int amount)
    {
        if (machine.CurrentState != playingState)
            return;

        score += amount;

        OnScoreChanged?.Invoke(score);
    }

    public void LoseLife()
    {
        if (machine.CurrentState != playingState)
            return;

        lives--;

        OnLivesChanged?.Invoke(lives);

        if (lives <= 0)
        {
            EndGame(false);
        }
    }

    public void UpdateTimer()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            currentTime = 0;
        }

        OnTimeChanged?.Invoke(currentTime);

        if (currentTime <= 0)
        {
            EndGame(true);
        }
    }

    public void EndGame(bool won)
    {
        if (machine.CurrentState == gameOverState)
            return;

        gameOverState.SetResult(won);

        ChangeState(gameOverState);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}