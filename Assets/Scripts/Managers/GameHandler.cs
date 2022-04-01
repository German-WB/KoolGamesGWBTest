using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public LevelData[] levelDataSO;
    public GameObject _countDownTimer;
    private PlayerMovement _playerMovement;
    private SpawnManager[] spawningData;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if(_playerMovement == null)
            _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        spawningData = FindObjectsOfType<SpawnManager>();
    }

    private void Start()
    {
        GameManager.instance.GameStarted += EnablePlayer;
        GameManager.instance.GameLost += DisablePlayer;
        GameManager.instance.Lvlpassed += EnableTimer;
        GameManager.instance.Lvlpassed += DisablePlayer;
        GameManager.instance.GameLost += LoadLevelSelector;
        StartCoroutine(SaveLevelAfterStartingRoutine());
    }



    private void EnablePlayer()
    {
        _playerMovement.enabled = true;
        Debug.Log("Enableo player");
    }

    private void DisablePlayer()
    {
        _playerMovement.enabled = false;
        Debug.Log("Disableo player");
    }

    private void EnableTimer()
    {
        _countDownTimer.SetActive(true);
    }

    private void DisableTimer()
    {
        _countDownTimer.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.instance.GameStarted -= EnablePlayer;
        GameManager.instance.GameLost -= DisablePlayer;
        GameManager.instance.Lvlpassed -= EnableTimer;
        GameManager.instance.Lvlpassed -= DisablePlayer;
        GameManager.instance.GameLost -= LoadLevelSelector;
    }

    private void LoadLevelSelector()
    {
        StartCoroutine(LoadDelayedLevel());
    }

    private IEnumerator LoadDelayedLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("LevelSelector");
    }

    private int GetActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void FillSOInfo()
    {
        if (GetActiveScene() == 2)
        {
            levelDataSO[0].cubeList = spawningData[0].SaveSpawningData();
            Debug.Log("Saving: " + levelDataSO[0]);
            //spawningData[0].SaveSpawningData();
        }
        else if (GetActiveScene() == 3)
        {
            levelDataSO[1].cubeList = spawningData[1].SaveSpawningData();
            Debug.Log("Saving: " + levelDataSO[1]);
        }
        else if(GetActiveScene() == 4)
        {
            levelDataSO[2].cubeList = spawningData[2].SaveSpawningData();
            Debug.Log("Saving: " + levelDataSO[2]);
        }
    }

    private IEnumerator SaveLevelAfterStartingRoutine()
    {
        yield return new WaitForSeconds(1f);
        FillSOInfo();
    }

}
