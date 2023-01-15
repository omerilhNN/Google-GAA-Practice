using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private int sceneIndex;
    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Score.lives--;
            Score.totalScore = 0;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
