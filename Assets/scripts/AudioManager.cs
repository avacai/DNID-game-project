using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } 

    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip buttonSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (Instance != this)
        {
            Destroy(gameObject); 
        }
    }
    public void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX (AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    void OnEnable()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

void OnDisable()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    
    if (scene.name == "SceneLevel1" || scene.name == "SceneLevel2" || scene.name == "SceneLevel3")
    {
        
        musicSource.Stop();
    }
    else
    {
       
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
}
