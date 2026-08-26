using UnityEngine;

public class PlayingState : IGameState
{
    private GameManager gameManager;

    public PlayingState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Enter()
    {
        Time.timeScale = 1f;
    }

    public void Tick()
    {
        gameManager.UpdateTimer();
    }

    public void Exit()
    {
    }
}