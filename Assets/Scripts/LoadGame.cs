using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    AudioSource ButtonSound;
    public Transform canvas;
    public Transform Player;

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
    public void ResumeGame()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<CharacterController>().enabled = true;
        Player.GetComponent<MouseLook>().canMove = true;
        Player.GetComponent<UserInteract>().enabled = true;
    }
}
