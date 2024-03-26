using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public int health = 3;
    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOverUI;
    public Jump jumpScript;
    public TMPro.TextMeshProUGUI finalScoreText;
    


    // Update is called once per frame
    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
        }
    }
        public void CheckGameOver()
    {
        if (health <= 0)
        {
            ShowGameOverScreen();
        }
    }
    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
            UpdateHearts();
            jumpScript.ResetScore();

            if (health <= 0)
            {
                jumpScript.GameOver();
            }
            else
            {
                jumpScript.ResetScore();
            }
        }
    }
        public void ShowGameOverScreen()
    {
        finalScoreText.text = "Total Score: " + jumpScript.scoreText.ToString();
        gameOverUI.SetActive(true); // This will show the Game Over screen
        
    }

    private void GameOver()
    {
        Debug.Log("Game over!");
    }

}
