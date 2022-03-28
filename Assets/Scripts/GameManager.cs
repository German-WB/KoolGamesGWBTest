using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlaying;

    public event Action gameStarted, gameLost;

    private void Awake()
    {
        instance = this;
        SoundManager.Initialize();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        gameStarted?.Invoke();
        Debug.Log("GameStarted Event");
    }

    public void LoseGame()
    {
        isPlaying = false;
        Debug.Log("GameLostEvent");
    }
}
