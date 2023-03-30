using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    private float time = 0f;
    private bool emit = false;
    public float randNum;
    public float lightStrength;

    public Material flickerMat;
    public Light theLight;

    private void Start()
    {
        RandGenerate();
    }
    void Update()
    {
        if (time >= randNum)
        {
            emit = !emit;
            if (emit)
            {
                flickerMat.EnableKeyword("_EMISSION");
                theLight.intensity = lightStrength;
            }
            else
            {
                flickerMat.DisableKeyword("_EMISSION");
                theLight.intensity = 0;
            }
            time = 0f;
            RandGenerate();
        }

        time += Time.deltaTime;
    }

    public void RandGenerate()
    {
        randNum = Random.Range(0.1f, 2.25f);
    }
}

