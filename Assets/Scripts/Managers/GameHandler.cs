using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    public GameObject _countDownTimer;
    // Start is called before the first frame update
    private void Awake()
    {
        if(_playerMovement == null)
            _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    private void Start()
    {
        GameManager.instance.GameStarted += EnablePlayer;
        GameManager.instance.GameLost += DisablePlayer;
        GameManager.instance.Lvlpassed += EnableTimer;
        GameManager.instance.Lvlpassed += DisablePlayer;
        GameManager.instance.GameLost += LoadLevelSelector;
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

}
