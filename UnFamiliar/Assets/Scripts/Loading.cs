using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadCanvas;
    public GameObject mainCanvas;
    public int lvlToLoad;

    public void LoadScene(int sceneId)
   {
        loadCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        StartCoroutine(LoadSceneAsync());
        Debug.Log("executed");
   }

   public IEnumerator LoadSceneAsync()
   {
        yield return new WaitForSeconds(2.5f);
        AsyncOperation opreation = SceneManager.LoadSceneAsync(lvlToLoad);
        yield return null;
   }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LoadScene(lvlToLoad);
        }
    }
}
