using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        scoreText.text = Score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            _audio.Play();
            Score.totalScore++;
            scoreText.text = "Score:" +Score.totalScore.ToString();
            Destroy(other.gameObject);
        }
    }
}
