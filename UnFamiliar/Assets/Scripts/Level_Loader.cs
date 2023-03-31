using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public AudioSource buttonSound;

    public GameObject loadCanvas;
    public GameObject mainCanvas;


    //public GameObject optionScreen;
    public void Forest()
    {
        SceneManager.LoadScene("Forest");
    }

    public void City()
    {
        SceneManager.LoadScene("City");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlaySound()
    {
        buttonSound.Play();
    }

    public void LoadScene(int sceneId)
    {
        loadCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        yield return null;
    }
}
