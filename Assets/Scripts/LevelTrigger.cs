using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    int sceneIndex;
    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex+1);
        }
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
