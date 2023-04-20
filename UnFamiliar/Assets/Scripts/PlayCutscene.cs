using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour
{
    public GameObject videoCanvas;
    public int videoLength;
    public Loading loading;
    public int levelToLoad;

    private void Start()
    {
        videoCanvas.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            videoCanvas.SetActive(true);
            StartCoroutine(VideoPlay());
        }
    }

    public IEnumerator VideoPlay()
    {
        yield return new WaitForSeconds(videoLength);
        videoCanvas.SetActive(false);
        loading.LoadScene(levelToLoad);
        Debug.Log("called to script");
    }
}
