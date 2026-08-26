using UnityEngine;

public class GameOverState : IGameState
{
    private GameManager gameManager;

    private bool playerWon;

    public GameOverState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void SetResult(bool won)
    {
        playerWon = won;
    }

    public void Enter()
    {
        Debug.Log("Estado atual: GAME OVER");

        if (playerWon)
        {
            Debug.Log("VITÓRIA!");
        }
        else
        {
            Debug.Log("DERROTA!");
        }

        gameManager.OnGameEnded?.Invoke(playerWon);
    }

    public void Tick()
    {

    }

    public void Exit()
    {
        Debug.Log("Saindo do GAME OVER");
    }
}