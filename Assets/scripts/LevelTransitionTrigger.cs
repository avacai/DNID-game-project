using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionTrigger : MonoBehaviour
{
    public GameObject uiPrompt;
    public string nextLevelName;

    private void Start()
    {
        uiPrompt.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiPrompt.SetActive(true); // Show the prompt
            Time.timeScale = 0; // Optionally pause the game
        }
    }

    public void EnterNextLevel()
    {
        Time.timeScale = 1; // Resume the game
        
        SceneManager.LoadScene(nextLevelName);
    }
}
