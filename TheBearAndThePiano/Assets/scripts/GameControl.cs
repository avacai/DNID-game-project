using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }
    public void MainMenu(){
        SceneManager.LoadScene("Main");
    }
    public void LoadNextScene()
    {
        // load the next scene in the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is not out of bounds
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Maybe loop back to the start or go to a main menu
            Debug.Log("No more scenes to load, returning to main menu or starting over.");
            SceneManager.LoadScene(0); 
        }
    }
    
    // Call this method when the player wins
    public void PlayerWon()
    {
        
        LoadNextScene();
    }
}
