using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float timeToNextLevel = 2f;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }        
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(timeToNextLevel);
        var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneIndex<SceneManager.sceneCountInBuildSettings)
        {
            FindObjectOfType<ScenePersist>().ResetScenePersistance();
            SceneManager.LoadScene(nextSceneIndex);            
        }
        else
        {

            FindObjectOfType<GameSession>().ResetGameSession();
            // SceneManager.LoadScene(0);
        }
    }
}
