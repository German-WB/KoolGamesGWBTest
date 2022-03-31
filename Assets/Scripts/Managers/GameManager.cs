using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlaying;

    public event Action GameStarted, GameLost, Lvlpassed;

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
        GameStarted?.Invoke();
        Debug.Log("GameStarted Event");
    }

    public void LoseGame()
    {
        isPlaying = false;
        GameLost?.Invoke();
        Debug.Log("GameLostEvent");
    }

    public void LvlPassed()
    {
        isPlaying = false;
        Lvlpassed?.Invoke();
        Debug.Log("LvlpassedEvent");
    }
}
