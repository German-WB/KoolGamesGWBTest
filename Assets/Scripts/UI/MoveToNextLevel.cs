using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    private Renderer _renderer;
    public Color startColor;
    public Color endColor;
    private bool transition;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        if (!transition)
            return;
        else
        {
            //GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
            _renderer.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.LvlPassed();
            SoundManager.PlaySound(SoundManager.Sound.LevelCompleted, GetPosition());
            StartCoroutine(LvlTimer());
            GoalFlickering();
        }
    }

    private void GoalFlickering()
    {
        //_renderer = GetComponent<Renderer>();
        // _renderer.material.SetFloat("_Smoothness", 1f);
        //_renderer.material.SetFloat("_Glossiness", 1f);
        //_material.SetFloat(1, 2);
        transition = true;
    }

    private Vector3 GetPosition()
    {
        return transform.position;
    }

    private IEnumerator LvlTimer()
    {
        yield return new WaitForSeconds(3.5f);

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Debug.Log("Finished all Lvls");
            SceneManager.LoadScene(1);

        }
        else
        {
            //Move to next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
}
