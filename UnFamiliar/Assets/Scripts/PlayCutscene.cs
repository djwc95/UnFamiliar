using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour
{
    public GameObject videoCanvas;
    public GameObject cutscene;
    public int videoLength;
    public Loading loading;
    public int levelToLoad;
    public CanvasGroup canvasGroup;
    public float fadeTime = 1.0f;

    private void Start()
    {
        videoCanvas.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            videoCanvas.SetActive(true);
            cutscene.SetActive(true);
            StartCoroutine(FadeIn());
            StartCoroutine(VideoPlay());
        }
    }

    public IEnumerator VideoPlay()
    {
        yield return new WaitForSeconds(videoLength);
        videoCanvas.SetActive(false);
        loading.LoadScene(levelToLoad);
    }

    private IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        yield return null;
    }

    private void Update()
    {
        if (videoCanvas.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                videoCanvas.SetActive(false);
                loading.LoadScene(levelToLoad);
            }
        }
    }
}
