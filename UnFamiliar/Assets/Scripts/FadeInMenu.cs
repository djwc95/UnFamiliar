using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMenu : MonoBehaviour
{
    public float fadeTime;
    public CanvasGroup canvas;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    private IEnumerator FadeIn()
    {
        while (canvas.alpha < 1f)
        {
            canvas.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        yield return null;
    }
}
