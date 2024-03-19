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
            if (health <= 0)
            {
                GameOver();
            }
        }
    }
        void ShowGameOverScreen()
    {
        gameOverUI.SetActive(true); // This will show the Game Over screen
        
    }
    private void GameOver()
    {
        Debug.Log("Game over!");
    }

}
