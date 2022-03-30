using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    // Start is called before the first frame update
    private void Awake()
    {
        if(_playerMovement == null)
            _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        GameManager.instance.gameStarted += EnablePlayer;
        GameManager.instance.gameLost += DisablePlayer;
    }

    public void EnablePlayer()
    {
        _playerMovement.enabled = true;
    }

    public void DisablePlayer()
    {
        _playerMovement.enabled = true;
    }

    private void OnDestroy()
    {
        GameManager.instance.gameStarted -= EnablePlayer;
        GameManager.instance.gameLost -= DisablePlayer;
    }

}
