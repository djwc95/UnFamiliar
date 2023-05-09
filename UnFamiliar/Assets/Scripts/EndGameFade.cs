using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameFade : MonoBehaviour
{
    public float fadeTime;
    public CanvasGroup canvas;
    public Loading loading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FadeIn()
    {
        while (canvas.alpha < 1f)
        {
            canvas.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(1f);
        loading.LoadScene(1);
        yield return null;
    }

    public void StartFade()
    {
        StartCoroutine(FadeIn());
    }
}
