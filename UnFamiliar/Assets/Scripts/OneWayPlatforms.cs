using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatforms : MonoBehaviour
{
    public GameObject[] platforms; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FallThrough());
        }
    }

    public IEnumerator FallThrough()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetActive(false);
        }

        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetActive(true);
        }
    }
}
