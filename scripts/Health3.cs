using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health3 : MonoBehaviour
{
    public int health = 3;
    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOverUI;
    public Jump3 jumpScript3;
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
            ShowGameOverScreen1();
        }
    }

    public void TakeDamage2()
    {
        if (health > 0)
        {
            health--;
            UpdateHearts();
            jumpScript3.ResetScore();

            if (health <= 0)
            {
                jumpScript3.GameOver();
            }
            else
            {
                jumpScript3.ResetScore();
            }
        }
    }
    public void ShowGameOverScreen1()
    {
        finalScoreText.text = "Total Score: " + jumpScript3.scoreText.ToString();
        gameOverUI.SetActive(true); // This will show the Game Over screen
        
    }
    private void GameOver()
    {
        Debug.Log("Game over!");
    }

}

