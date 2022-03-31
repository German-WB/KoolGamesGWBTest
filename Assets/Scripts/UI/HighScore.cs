using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text score;
    private CubeStack _cubeStack;

    // Start is called before the first frame update
    void Start()
    {
        _cubeStack = GameObject.Find("Player").GetComponent<CubeStack>();
        score.text = "Best Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        GameManager.instance.Lvlpassed += UpdateHighestScore;
    }

    void UpdateHighestScore()
    {
        int multiplier = _cubeStack.GetStackedCubes();

        if (multiplier * 10 > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", 10 * multiplier);
            score.text = "Best Score: " + (10 * multiplier).ToString();
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.Lvlpassed -= UpdateHighestScore;
    }
}
