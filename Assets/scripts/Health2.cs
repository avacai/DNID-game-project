using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health2 : MonoBehaviour
{
    public int health = 3;
    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOverUI;
    public Jump2 jumpScript2;
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
            jumpScript2.ResetScore();

            if (health <= 0)
            {
                jumpScript2.GameOver();
            }
            else
            {
                jumpScript2.ResetScore();
            }
        }
    }
    public void ShowGameOverScreen1()
    {
        finalScoreText.text = "Total Score: " + jumpScript2.scoreText.ToString();
        gameOverUI.SetActive(true); 
        
    }
    private void GameOver()
    {
        Debug.Log("Game over!");
    }

}
