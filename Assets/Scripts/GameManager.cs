using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player;
    public MissileController missile;
    private bool gameOver = false;
    private bool isGameActive = false;

    public bool IsGameActive => isGameActive;
    public bool IsGameOver => gameOver;

    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        isGameActive = true;
        missile.Launch();
        gameOver = false;
    }

    public void PlayerHit()
    {
        if (!gameOver)
        {
            gameOver = true;
            isGameActive = false;
            player.PlayerMove(false);
            UIManager.Instance.ShowGameResult("Ви програли! Літак вражений.");
        }
    }

    public void MissileOutOfFuel()
    {
        if (!gameOver)
        {
            gameOver = true;
            isGameActive = false;
            player.PlayerMove(false);
            UIManager.Instance.ShowGameResult("Ви перемогли! Ракета вичерпала пальне.");
        }
    }
}
