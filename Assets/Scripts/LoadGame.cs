using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    AudioSource ButtonSound;

    public void PlayGame()
    {
        ButtonSound = GetComponent<AudioSource>();
        ButtonSound.Play();
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        ButtonSound = GetComponent<AudioSource>();
        ButtonSound.Play();
        SceneManager.LoadScene(2);
    }

    public void BackToMenu()
    {
        ButtonSound = GetComponent<AudioSource>();
        ButtonSound.Play();
        SceneManager.LoadScene(0);
    }

    public void ShowStory()
    {
        ButtonSound = GetComponent<AudioSource>();
        ButtonSound.Play();
        SceneManager.LoadScene(3); 
    }

    public void QuitGame()
    {
        ButtonSound = GetComponent<AudioSource>();
        ButtonSound.Play();
        Debug.Log("QUIT");
        Application.Quit();
    }
}
