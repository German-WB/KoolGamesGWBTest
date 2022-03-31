using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.LvlPassed();
            StartCoroutine(LvlTimer());
        }
    }

    private IEnumerator LvlTimer()
    {
        yield return new WaitForSeconds(3.5f);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Debug.Log("Finished all Lvls");
            SceneManager.LoadScene(1);
            //Show Win Screen or Somethin.
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
