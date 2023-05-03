using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRainFall : MonoBehaviour
{
    public GameObject heavyRain;
    public GameObject lightRain;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            heavyRain.SetActive(false);
            lightRain.SetActive(true);
        }
    }
}
