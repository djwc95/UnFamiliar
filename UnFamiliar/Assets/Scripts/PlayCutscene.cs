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
    //public AudioSource[] sourcesToDisable;

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
            StartCoroutine(StopAudio());
        }
    }

    public IEnumerator VideoPlay()
    {
        yield return new WaitForSeconds(videoLength);
        videoCanvas.SetActive(false);
        loading.LoadScene(levelToLoad);
    }

    public IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        StartCoroutine(VideoPlay());
    }

    private void Update()
    {
        if (videoCanvas.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                videoCanvas.SetActive(false);
                var cutsceneAudio = GetComponentInChildren<AudioSource>();
                cutsceneAudio.Stop();
                loading.LoadScene(levelToLoad);
            }
        }
    }

    public IEnumerator StopAudio()
    {
        var allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }

        yield return new WaitForSeconds(.25f);
        StartCoroutine(FadeIn());
        
    }

    public void MenuVideo()
    {
        videoCanvas.SetActive(true);
        cutscene.SetActive(true);
        StartCoroutine(StopAudio());
    }
}
