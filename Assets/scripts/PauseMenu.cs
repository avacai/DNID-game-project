using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject PausePannel;
    void Update(){

    }
    public void Pause(){
        PausePannel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue(){
        PausePannel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Home(){
        SceneManager.LoadScene("Main");
    }
}
