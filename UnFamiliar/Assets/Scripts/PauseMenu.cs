using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject confirmQuit;
    private bool paused;
    public AudioSource buttonSound;

    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        confirmQuit = GameObject.FindGameObjectWithTag("ConfirmQuit");
        paused = false;
        pauseMenu.SetActive(false);
        confirmQuit.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !paused) //esc pauses if not paused
        {
            pauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetButtonDown("Cancel") && paused) //esc resumes game if paused
        {
            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        buttonSound.Play();
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ConfirmQuit()
    {
        buttonSound.Play();
        confirmQuit.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CancelQuit()
    {
        buttonSound.Play();
        confirmQuit.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
