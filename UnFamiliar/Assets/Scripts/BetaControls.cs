using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetaControls : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BetaControls");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PreviousScene();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ReloadScene();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NextScene();
        }
        
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
